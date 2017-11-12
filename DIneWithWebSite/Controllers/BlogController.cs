using DIneWithWebSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebSite.Models;

namespace WebSite.Controllers
{   [RequireHttps]
    public class BlogController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                if (user.Name.SequenceEqual("Administrator@gmail.com"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // GET: Blog
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayAdmin = "No";

                if (isAdminUser())
                {
                    ViewBag.displayAdmin = "Yes";
                }
                return View(db.Posts.ToList());
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            
            return View(db.Posts.ToList());
            
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.PublishDate = DateTime.Now;
                post.totalNumberOfVotes = 0;
                post.totalVoteCount = 0;
                post.Rating = 0;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
           
            foreach (var item in post.Comments)
            {
                item.Post = db.Posts.FirstOrDefault(x => x.ID == item.RelatedPost);
                db.Comments.Remove(db.Comments.First(y => y.ID == item.ID));
                db.SaveChanges();
            }
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // SET: Blog/AddComment
        public ActionResult AddComment(Comment c)
        {

            c.Post = db.Posts.FirstOrDefault(post => post.ID == c.RelatedPost);
            db.Comments.Add(c);
            db.SaveChanges();

            return RedirectToAction("Details",new {id = c.Post.ID });
            
        }
        public ActionResult DeleteComment(Comment c)
        {
            c.Post = db.Posts.FirstOrDefault(post => post.ID == c.RelatedPost);
            db.Comments.Remove(db.Comments.First(x => x.ID == c.ID));
            db.SaveChanges();

            return RedirectToAction("Details", new { id = c.Post.ID });

        }


        //search for specific restaurant
        public ActionResult SearchForRestaurant(string restaurantName, string cuisine, string meal, string authorName, string numOfReviews)
        {
            if(String.IsNullOrEmpty(restaurantName)&& String.IsNullOrEmpty(cuisine)&& String.IsNullOrEmpty(meal)
                && String.IsNullOrEmpty(authorName)&& String.IsNullOrEmpty(numOfReviews)){
                return RedirectToAction("NotFound");
            }

            var query = from p in db.Posts
                        select p;
            
            if (!String.IsNullOrEmpty(restaurantName))
            { 
                query = query.Where(p => p.Title.ToUpper().Contains(restaurantName.ToUpper()));
            }
            if (!String.IsNullOrEmpty(cuisine))
            {
                query = query.Where(p => p.Cuisine.ToUpper().Contains(cuisine.ToUpper()));
            }
            if (!String.IsNullOrEmpty(meal))
            {
                query = query.Where(p => p.Meals.ToUpper().Contains(meal.ToUpper()));
            }
            if (!String.IsNullOrEmpty(authorName))
            {
                query = query.Where(p => p.Writer.ToUpper().Contains(authorName.ToUpper()));
            }
            if (!String.IsNullOrEmpty(numOfReviews))
            {
                int number = Int32.Parse(numOfReviews);
                query = query.Where(p => p.Comments.Count>= number);
            }
            
            var posts = query.ToArray();
            if (posts == null || posts.Length == 0)
            {
                return RedirectToAction("NotFound");
            }
            else
                return View(posts.ToList());
        }

        public ActionResult NotFound()
        {
            return View();
        }


        //Rating
        public JsonResult SendRating(string r, string s, string id, string url)
        {
            int autoId = 0;
            Int16 thisVote = 0;
            Int16 sectionId = 0;
            Int16.TryParse(s, out sectionId);
            Int16.TryParse(r, out thisVote);
            int.TryParse(id, out autoId);

            if (!User.Identity.IsAuthenticated)
            {
                return Json("Not authenticated!");
            }

            if (autoId.Equals(0))
            {
                return Json("Sorry, record to vote doesn't exists");
            }

            switch (s)
            {
                case "5":
                    // check if he has already voted
                    var isIt = db.Votes.Where(v => v.SectionID == sectionId &&
                        v.UserName.Equals(User.Identity.Name, StringComparison.CurrentCultureIgnoreCase) && v.VoteForID == autoId).FirstOrDefault();
                    if (isIt != null)
                    {
                        // keep the restaurant voting flag to stop voting by this member
                        HttpCookie cookie = new HttpCookie(url, "true");
                        Response.Cookies.Add(cookie);
                        return Json("<br />You have already rated this post, thanks !");
                    }

                    var sch = db.Posts.Where(sc => sc.ID == autoId).FirstOrDefault();
                    if (sch != null)
                    {
                        //calculating the average rating of each post and saving to DB
                        sch.totalNumberOfVotes++;
                        sch.totalVoteCount += thisVote;
                        sch.Rating = sch.totalVoteCount / sch.totalNumberOfVotes;

                        object obj = sch.Votes;

                        string updatedVotes = string.Empty;
                        string[] votes = null;
                        if (obj != null && obj.ToString().Length > 0)
                        {
                            string currentVotes = obj.ToString(); // votes pattern will be 0,0,0,0,0
                            votes = currentVotes.Split(',');
                            // if proper vote data is there in the database
                            if (votes.Length.Equals(5))
                            {
                                // get the current number of vote count of the selected vote, always say -1 than the current vote in the array 
                                int currentNumberOfVote = int.Parse(votes[thisVote - 1]);
                                // increase 1 for this vote
                                currentNumberOfVote++;
                                // set the updated value into the selected votes
                                votes[thisVote - 1] = currentNumberOfVote.ToString();
                            }
                            else
                            {
                                votes = new string[] { "0", "0", "0", "0", "0" };
                                votes[thisVote - 1] = "1";
                            }
                        }
                        else
                        {
                            votes = new string[] { "0", "0", "0", "0", "0" };
                            votes[thisVote - 1] = "1";
                        }

                        // concatenate all arrays now
                        foreach (string ss in votes)
                        {
                            updatedVotes += ss + ",";
                        }
                        updatedVotes = updatedVotes.Substring(0, updatedVotes.Length - 1);

                        db.Entry(sch).State = EntityState.Modified;
                        sch.Votes = updatedVotes;
                        db.SaveChanges();

                        VoteLog vm = new VoteLog()
                        {
                            Active = true,
                            SectionID = Int16.Parse(s),
                            UserName = User.Identity.Name,
                            Vote = thisVote,
                            VoteForID = autoId
                        };

                        db.Votes.Add(vm);

                        db.SaveChanges();

                        // keep the restaurant voting flag to stop voting by this member
                        HttpCookie cookie = new HttpCookie(url, "true");
                        Response.Cookies.Add(cookie);
                    }
                    break;
                default:
                    break;
            }
            return Json("<br />You rated " + r + " star(s), thanks !");
        }

        //Join Posts Table and Comment Table to view all posts that have revies
        public ActionResult PostsWithReviews()
        {
            List<Comment> CommentList = new List<Comment>();
            try
            {
                CommentList = db.Comments.ToList();
                var NewList = CommentList.GroupJoin(db.Posts, comment => comment.RelatedPost,
                post => post.ID,
                (x, y) => new CommentPost(x, y.FirstOrDefault()));

                List<CommentPost> List = NewList.ToList<CommentPost>();

                return View(List);
            }

            catch (Exception ex)
            {

                RedirectToAction("Index", "Blog",ex);
            }
                return View();
        }


        //Return Statistics view
        public ActionResult GroupByCuisine()
        {
            return View();
        }

        //Calculate Statistics for D3 + Using GroupBy
        public ActionResult Statistics()
        {
               var Cuisines = db.Posts.GroupBy(x => x.Cuisine).Select(grp => new {
                        Cuisine = grp.FirstOrDefault().Cuisine,
                        Count = grp.Count()
                    }).ToList();
                ViewBag.Cuisines = JsonConvert.SerializeObject(Cuisines);

                var Ratings = db.Posts.Select(x => new {
                    Title =x.Title,
                    Rating =x.Rating
                }).ToList();
                ViewBag.Ratings = JsonConvert.SerializeObject(Ratings);
                return View();
            
        }

        //Calculates the Relevant details for the INTRO
        public ActionResult calcBestRating()
        {
            int ID = 0;
            Single Rating=0;
            foreach (var item in db.Posts)
            {
                if (item.Rating > Rating)
                {
                    Rating = item.Rating;
                    ID = item.ID;
                }
            }
            return RedirectToAction("Details", new { id = ID });
        }

        public String BestRatingName()
        {
            Single Rating = 0;
            String Title = "";
            foreach (var item in db.Posts)
            {
                if (item.Rating > Rating)
                {
                    Rating = item.Rating;
                    Title = item.Title;
                }
            }
            return Title;
        }



    }
}

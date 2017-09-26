using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class BlogController : Controller
    {
        private BlogDBContext db = new BlogDBContext();

        // GET: Blog
        public ActionResult Index()
        {
         
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


    }
}

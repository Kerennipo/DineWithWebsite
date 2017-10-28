using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Kernels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{   [RequireHttps]
    public class FansController : Controller
    {
        private FanDBContext db = new FanDBContext();
        static List<double[]> inputsTraining = new List<double[]>();
        static List<int> outputsTraining = new List<int>();

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

        // GET: Fans
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
                return View(db.Fan.ToList());
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }

            return View(db.Fan.ToList());
        }

        // GET: Fans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db.Fan.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        // GET: Fans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,BDay,Seniority,IsVegeterian")] Fan fan)
        {
            if (ModelState.IsValid)
            {
                if (inputsTraining.Count==0&&outputsTraining.Count==0)
                {
                    inisializeSVM();
                }
                double[] vector=FanToVector(fan);
                fan.FanOfWinning = SVM(vector);
                inputsTraining.Add(vector);
                outputsTraining.Add(System.Convert.ToInt32(fan.FanOfWinning));
                
                db.Fan.Add(fan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fan);
        }

        // GET: Fans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db.Fan.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        // POST: Fans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Gender,BDay,Seniority")] Fan fan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fan);
        }

        // GET: Fans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db.Fan.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        // POST: Fans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fan fan = db.Fan.Find(id);
            db.Fan.Remove(fan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Random inisialize for SVM algorithm use (if DB is empty)
        private void inisializeSVM()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                inputsTraining.Add(new double[] { random.Next(0,2), random.Next(0,2) });
                outputsTraining.Add(random.Next(0,2));
            }
        }

        //SVM algorithm to check if a Fan loved the winning restaurant or not
        private bool SVM(double[] vector)
        {
            // Create the learning algorithm with the chosen kernel
            var smo = new SequentialMinimalOptimization<Gaussian>()
            {
                Complexity = 100 // Create a hard-margin SVM 
            };

            // Use the algorithm to learn the svm
            var svm = smo.Learn(inputsTraining.ToArray(), outputsTraining.ToArray());

            // Compute the machine's answers for the given inputs
            bool prediction = svm.Decide(vector);

            return prediction;
        }

        private double[] FanToVector(Fan fan)
        {
            if (fan.Gender.Equals("Female"))
            { 
                return new double[] {1,System.Convert.ToDouble(fan.IsVegeterian)};
            }
            return new double[] {0,System.Convert.ToDouble(fan.IsVegeterian)};
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solarsplash_Dataviewer.Models;

namespace Solarsplash_Dataviewer.Controllers
{ 
    public class DataController : Controller
    {
        private SolarsplashEntities db = new SolarsplashEntities();

        //
        // GET: /Data/

        public ViewResult Index()
        {
            return View(db.RunData.ToList());
        }

        //
        // GET: /Data/Details/5

        public ViewResult Details(int id)
        {
            //RunData rundata = db.RunData.Find(id);
            RunData rundata = (from RunData in db.RunData.Include("Runs") where RunData.id == id select RunData).First();
            int test = rundata.Runs.Count;
            return View(rundata);
        }

        //
        // GET: /Data/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Data/Create

        [HttpPost]
        public ActionResult Create(RunData rundata)
        {
            if (ModelState.IsValid)
            {
                db.RunData.Add(rundata);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(rundata);
        }
        
        //
        // GET: /Data/Edit/5
 
        public ActionResult Edit(int id)
        {
            RunData rundata = db.RunData.Find(id);
            return View(rundata);
        }

        //
        // POST: /Data/Edit/5

        [HttpPost]
        public ActionResult Edit(RunData rundata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rundata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rundata);
        }

        //
        // GET: /Data/Delete/5
 
        public ActionResult Delete(int id)
        {
            RunData rundata = db.RunData.Find(id);
            return View(rundata);
        }

        //
        // POST: /Data/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            RunData rundata = db.RunData.Find(id);
            db.RunData.Remove(rundata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
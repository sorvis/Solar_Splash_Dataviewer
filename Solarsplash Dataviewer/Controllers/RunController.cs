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
    public class RunController : Controller
    {
        private SolarsplashEntities db = new SolarsplashEntities();

        //
        // GET: /Run/

        public ViewResult Index()
        {
            return View(db.RunData.ToList());
        }

        //
        // GET: /Run/Details/5

        public ViewResult Details(string id)
        {
            RunData rundata = db.RunData.Find(id);
            return View(rundata);
        }

        //
        // GET: /Run/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Run/Create

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
        // GET: /Run/Edit/5
 
        public ActionResult Edit(string id)
        {
            RunData rundata = db.RunData.Find(id);
            return View(rundata);
        }

        //
        // POST: /Run/Edit/5

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
        // GET: /Run/Delete/5
 
        public ActionResult Delete(string id)
        {
            RunData rundata = db.RunData.Find(id);
            return View(rundata);
        }

        //
        // POST: /Run/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
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
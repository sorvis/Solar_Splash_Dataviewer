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
    public class DataRunController : Controller
    {
        private SolarsplashEntities db = new SolarsplashEntities();

        //
        // GET: /DataRun/

        public ViewResult Index()
        {
            return View(db.RunData.ToList());
        }

        //
        // GET: /DataRun/Details/5

        public ViewResult Details(int id)
        {
            RunData rundata = db.RunData.Find(id);
            return View(rundata);
        }

        //
        // GET: /DataRun/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /DataRun/Create

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
        // GET: /DataRun/Edit/5
 
        public ActionResult Edit(int id)
        {
            RunData rundata = db.RunData.Find(id);
            return View(rundata);
        }

        //
        // POST: /DataRun/Edit/5

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
        // GET: /DataRun/Delete/5
 
        public ActionResult Delete(int id)
        {
            RunData rundata = db.RunData.Find(id);
            return View(rundata);
        }

        //
        // POST: /DataRun/Delete/5

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
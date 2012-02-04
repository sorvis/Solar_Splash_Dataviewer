using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solarsplash_Dataviewer.Models;
using System.IO;
using Solarsplash_Dataviewer.Controllers.Send_To_Database;

namespace Solarsplash_Dataviewer.Controllers
{
    public class UploadController : Controller
    {
        private SolarsplashEntities db = new SolarsplashEntities();

        //
        // GET: /Upload/

        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Upload/
        // This action handles the form POST and the upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);

                //save to database
                RunData data = CSVToData.add(file);
                db.RunData.Add(data);

                db.SaveChanges();
            }
            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
    }
}

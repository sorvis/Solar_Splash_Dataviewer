using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solarsplash_Dataviewer.Models;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Controllers
{
    public class AnalysisController : Controller
    {
        private EF_RunDataRepository _db = new EF_RunDataRepository();

        //
        // GET: /Analysis/Display/4

        public ActionResult Display(int id)
        {
            return View(_db.Get_RunData_Analyers_and_DataLabels(id));
        }

        //
        // GET: /Analysis/Add_Display/3

        public ActionResult Add_Display(int id)
        {
            List<DataLabel> labels = _db.Get_RunData_Analyers_and_DataLabels(id).DataLabels;
            ViewBag.Dropdown_for_labels = new IndexViewModel()
            {
                ListItems = labels
            };
            return View();
        }

    }
}

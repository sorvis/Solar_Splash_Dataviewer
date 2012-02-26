using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using Solarsplash_Dataviewer.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Controllers
{
    public class POST_DataController : Controller
    {
        private IRunDataRepository _repository;
        public POST_DataController() : this(new EF_RunDataRepository()){}
        public POST_DataController(IRunDataRepository repository)
        {
            _repository = repository;
        }
        //private SolarsplashEntities db = new SolarsplashEntities();

        //
        // GET: /POST_Data/Add?name=testName&number=3&data=2.4,0.3,4,3

        public ActionResult Add(string name, int number, string data)
        {
            string hash = name+number+data;
            hash = GetMd5Hash(hash);
            ViewBag.hash = hash;

            RunElement run = RunElement_Factory.get(number, data.Split(',').ToList());

            _repository.Add_RunElement_to_RunData(name, run);

            return View();
        }

        //
        // GET: /POST_Data/AddRun?name=firstRun&labels=SVOL,SBOD

        public ActionResult AddRun(string name, string labels)
        {
            string hash = name + labels;
            hash = GetMd5Hash(hash);

            _repository.Add_New_Run(name, DataLabel.MakeRange(labels.Split(',').ToList()));

            ViewBag.hash = hash;
            return View();
        }

        //// BEGIN: Private functions
        ////
        ////

        ///// <summary>
        ///// auto creates a run object if needed
        ///// returns wheather it had to add object to database
        ///// </summary>
        ///// <param name="runName"></param>
        ///// <returns></returns>
        //private bool createRunDataInDB_if_needed(string runName)
        //{
        //    RunData rundata = (from RunData in db.RunData
        //                       where RunData.Name == runName
        //                       select RunData).First();

        //    if (rundata == null)
        //    {
        //        RunData run = new RunData();
        //        run.Name = runName;
        //        db.RunData.Add(run);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        //private bool deleteRunDataObject(RunData runData)
        //{
        //    using (SolarsplashEntities context = db)
        //    {
        //        try
        //        {
        //            ObjectContext oc = ((IObjectContextAdapter)context).ObjectContext;
        //            oc.DeleteObject(runData);
        //            oc.SaveChanges();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //}
        //private RunData getFullRunDataObject(string Name)
        //{
        //    //return (from RunData in db.RunData.Include("Runs").Include("DataLabels")
        //    //    where RunData.Name == Name
        //    //    select RunData).First();

        //    using (SolarsplashEntities context = db)
        //    {
        //        try
        //        {
        //            return context.RunData.Include("Runs").Include("DataLabels").Where<RunData>(RunData => RunData.Name == Name).First();
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}
        //private void addRunDataToDB(RunData run)
        //{
        //    db.RunData.Add(run);
        //    db.SaveChanges();
        //}

        //private bool addRunElementToDB(RunElement run, string name)
        //{
        //    RunData rundata;
        //    //rundata = (from RunData in db.RunData.Include("Runs")
        //    //                   where RunData.Name == name
        //    //                   select RunData).First();

        //    using (SolarsplashEntities context = db)
        //    {
        //        try
        //        {
        //            rundata = context.RunData.Include("Runs").Include("DataLabels").Where<RunData>(RunData => RunData.Name == name).First();
        //        }
        //        catch
        //        {
        //            return false;
        //        }

        //        rundata.Runs.Add(run);
        //        context.SaveChanges();
        //        return true;
        //    }
        //}

        private static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}

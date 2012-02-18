using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using Solarsplash_Dataviewer.Models;

namespace Solarsplash_Dataviewer.Controllers
{
    public class POST_DataController : Controller
    {
        private SolarsplashEntities db = new SolarsplashEntities();

        //
        // GET: /POST_Data/Add?name=testName&number=3&data=2.4,0.3,4,3

        public ActionResult Add(string name, int number, string data)
        {
            string hash = name+number+data;
            hash = GetMd5Hash(MD5.Create(), hash);
            ViewBag.hash = hash;

            RunElement run = RunElement_Factory.get(number, data.Split(',').ToList());

            return View();
        }

        /// <summary>
        /// auto creates a run object if needed
        /// returns wheather it had to add object to database
        /// </summary>
        /// <param name="runName"></param>
        /// <returns></returns>
        private bool createRunDataInDB_if_needed(string runName)
        {
            RunData rundata = (from RunData in db.RunData
                               where RunData.Name == runName
                               select RunData).First();

            if (rundata == null)
            {
                RunData run = new RunData();
                run.Name = runName;
                db.RunData.Add(run);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private void addRunElementToDB(RunElement run, string name)
        {
            RunData rundata = (from RunData in db.RunData.Include("Runs")
                               where RunData.Name == name
                               select RunData).First();

            rundata.Runs.Add(run);
            db.SaveChanges();
        }

        //
        // GET: /POST_Data/AddRun?name=firstRun&labels=SVOL,SBOD

        public ActionResult AddRun(string name, string labels)
        {
            string hash = name + labels;
            hash = GetMd5Hash(MD5.Create(), hash);

            ViewBag.hash = hash;
            return View();
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

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

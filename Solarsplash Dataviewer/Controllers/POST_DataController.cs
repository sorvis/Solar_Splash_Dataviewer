﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Solarsplash_Dataviewer.Controllers
{
    public class POST_DataController : Controller
    {
        //
        // GET: /POST_Data/Add?name=testName&number=3&data=2,3,4,3

        public ActionResult Add(string name, int number, string data)
        {
            string hash = name+number+data;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, hash);
            }

            ViewBag.hash = hash;
            return View();
        }

        //
        // GET: /POST_Data/AddRun?name=firstRun&labels=SVOL,SBOD

        public ActionResult AddRun(string name, string labels)
        {
            string hash = name + labels;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, hash);
            }

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

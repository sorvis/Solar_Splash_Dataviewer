using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solarsplash_Dataviewer.Models;
using System.IO;

namespace Solarsplash_Dataviewer.Controllers.Send_To_Database
{
    static public class CSVToData
    {
        public static RunData add(HttpPostedFileBase file)
        {
            RunData run = new RunData();
            run.Name = file.FileName;
            run.AcrchivedFileName = file.FileName;
            run.Acrchived = false;
            DateTime timeDate = DateTime.Now.ToLocalTime();
            run.id = timeDate.ToString();
            run.Runs = readFileToDB(file.InputStream, run.id);

            return run;
        }
        private static List<RunElement> readFileToDB(Stream file, string ID_RunDate)
        {
            using(StreamReader sr = new StreamReader(file))
            {
                string line;

                //read first line for data labels
                line = sr.ReadLine();
                string[] dataLabels = line.Split(',');

                string[] tempData;

                List<RunElement> data = new List<RunElement>(); //list of time snapshots

                int runElementId = 0;
                // read all the data in the file
                while((line=sr.ReadLine())!=null)
                {
                    tempData = line.Split(',');

                    List<ElementItem> dataList = new List<ElementItem>();   // list of data in one time snapshot

                    //go through each item in tempdata
                    for(int i = 0; i<tempData.Count(); i++)
                    {
                        dataList.Add(new ElementItem(dataLabels[i], Convert.ToSingle(tempData[i])));
                    }
                    data.Add(new RunElement(dataList, ID_RunDate, ID_RunDate+"--"+runElementId));
                    runElementId++;
                }
                return data;
            }
        }
    }
}
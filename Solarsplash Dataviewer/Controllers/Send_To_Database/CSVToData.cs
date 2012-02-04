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
            //run.id = timeDate.ToString();
            run.Runs = readFileToDB(file.InputStream);

            return run;
        }
        private static List<RunElement> readFileToDB(Stream file)
        {
            using(StreamReader sr = new StreamReader(file))
            {
                string line;

                //read first line for data labels
                line = sr.ReadLine();
                string[] dataLabels = line.Split(',');

                string[] tempData;
                RunElement tempElement;

                List<RunElement> data = new List<RunElement>(); //list of time snapshots

                int runElementId = 0;
                // read all the data in the file
                while((line=sr.ReadLine())!=null)
                {
                    tempData = line.Split(',');

                    //Make a RunElement to put this snapshot of data into
                    tempElement = new RunElement();
                    runElementId++;

                    //go through each item in tempdata
                    for(int i = 0; i<tempData.Count(); i++)
                    {
                        tempElement.DataLabels.Add(dataLabels[i]);
                        tempElement.Data.Add(Convert.ToSingle(tempData[i]));
                    }
                    data.Add(tempElement);
                }
                return data;
            }
        }
    }
}
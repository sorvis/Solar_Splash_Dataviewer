using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solarsplash_Dataviewer.Models;
using System.IO;
using Solarsplash_Dataviewer.Models.RunElements;

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

            //give the data label stream reader is own copy of the stream to work on
            Stream dataLabelStream = new MemoryStream(); ;
            file.InputStream.CopyTo(dataLabelStream);
            dataLabelStream.Position = 0;
            run.DataLabels = DataLabel.MakeRange(readDataLabels(dataLabelStream).ToList());

            run.Runs = readFileToDB(file.InputStream);

            return run;
        }
        private static string[] readDataLabels(Stream file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                return sr.ReadLine().Split(',');
            }
        }
        private static List<RunElement> readFileToDB(Stream file)
        {
            using(StreamReader sr = new StreamReader(file))
            {
                string line;
                string[] tempData;
                RunElement tempElement;

                // to prevent errors reset stream then fake reading in the data labels
                file.Position = 0;
                sr.ReadLine();

                List<RunElement> data = new List<RunElement>(); //list of time snapshots

                int runElementId = 0;
                // read all the data in the file
                while((line=sr.ReadLine())!=null)
                {
                    tempData = line.Split(',');

                    //Make a RunElement to put this snapshot of data into
                    tempElement = new RunElement();

                    //go through each item in tempdata
                    for(int i = 0; i<tempData.Count(); i++)
                    {
                        tempElement.Data.Add(new Data(Convert.ToSingle(tempData[i])));
                    }
                    tempElement.Number = runElementId;
                    runElementId++;
                    data.Add(tempElement);
                }
                return data;
            }
        }
    }
}
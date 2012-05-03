using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Solarsplash_Dataviewer.Models.DataAnalysis;

namespace Solarsplash_Dataviewer.Models.RunElements
{
    public class DataLabel
    {
        [Key]
        public int id_DataLabel { get; set; }
        public RunData RunData { get; set; }    //for parent ID
        public int parent;
        public string LabelName { get; set; }
        public List<Analyzer> Analyzers { get; set; }
        public DataLabel()
        {
        }
        public DataLabel(string name)
        {
            LabelName = name;
            Analyzers = new List<Analyzer>();
        }
        public static List<DataLabel> MakeRange(List<string> items)
        {
            List<DataLabel> tempList = new List<DataLabel>();
            foreach (string item in items)
            {
                tempList.Add(new DataLabel(item));
            }
            return tempList;
        }
    }
}
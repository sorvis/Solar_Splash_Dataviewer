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
        public int id { get; set; }
        public string LabelName { get; set; }
        public List<IAnalyzer> Analyzers { get; set; }
        public DataLabel()
        {
        }
        public DataLabel(string name)
        {
            LabelName = name;
            Analyzers = new List<IAnalyzer>();
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
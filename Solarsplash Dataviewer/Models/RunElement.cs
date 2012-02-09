using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Solarsplash_Dataviewer.Models
{
    /// <summary>
    /// Represents one snapshot in time of data on a run
    /// </summary>
    public class RunElement
    {
        //public string Time { get; set; }

        [Key]
        public int id { get; set; }

        public int Number { get; set; }

        public List<string> DataLabels { get; set; }
        public List<float> Data { get; set; }

        public RunElement()
        {
            Data = new List<float>();
            DataLabels = new List<string>();
        }
    }
}
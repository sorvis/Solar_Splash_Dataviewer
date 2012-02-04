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
        public string id { get; set; }
        public string Parent_RunDataKey { get; set; }
        public List<ElementItem> Items { get; set; }
        public RunElement(List<ElementItem> Items, string parent, string ID)
        {
            this.Items = Items;
            id = ID;
            Parent_RunDataKey = parent;
        }
    }
}
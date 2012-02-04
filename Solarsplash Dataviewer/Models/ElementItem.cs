using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Solarsplash_Dataviewer.Models
{
    /// <summary>
    /// One of the data items held within a snapshot of time
    /// </summary>
    public class ElementItem
    {
        [Key]
        public string id { get; set; }
        public int Parent_RunElementKey { get; set; }
        public string Label { get; set; }
        public float Data { get; set; }
        public ElementItem(String Label, float Data)
        {
            this.Label = Label;
            this.Data = Data;
        }
    }
}
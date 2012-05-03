using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Solarsplash_Dataviewer.Models
{
    public class DataLabelDefinition
    {
        [Key]
        public string defaultLabel { get; set; }    // this is the label the Android will use to save the data --> the label ultimently comes from the microcontroller
        public string Name { get; set; }    // this is the human readable name of data item
        public string description { get; set; } // allows user to define in detial where data is coming from
    }
}
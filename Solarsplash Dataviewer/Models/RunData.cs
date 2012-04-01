using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Models
{
    /// <summary>
    /// All the data held for one run
    /// </summary>
    public class RunData
    {
        [Key]
        [Required]
        public int id_RunData { get; set; }
        public string Name { get; set; }            //user defined display name for the run
        public List<RunElement> Runs { get; set; }
        public string Description { get; set; }     //place for user to put notes or what ever about the run
        public DateTime? DateAndTime { get; set; }   //the data and time which is stored in the original filename the Android made
        public List<DataLabel> DataLabels { get; set; }

        //Archive information
        public bool Acrchived { get; set; }
        
        public string AcrchivedFileName { get; set; }

        public RunData()
        {
            do_setup();
        }
        public RunData(string name)
        {
            Name = name;
            do_setup();
        }
        private void do_setup()
        {
            Runs = new List<RunElement>();
            DataLabels = new List<RunElements.DataLabel>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solarsplash_Dataviewer.Models
{
    /// <summary>
    /// All the data held for one run
    /// </summary>
    public class RunData
    {
        public string Name { get; set; }            //user defined display name for the run
        public List<RunElement> Runs { get; set; }
        public string Description { get; set; }     //place for user to put notes or what ever about the run
        public DateTime DateAndTime { get; set; }   //the data and time which is stored in the original filename the Android made

        //Archive information
        public bool Acrchived { get; set; }
        public string AcrchivedFileName { get; set; }
    }

    /// <summary>
    /// Represents one snapshot in time of data on a run
    /// </summary>
    public struct RunElement
    {
        public string Time { get; set; }
        public List<ElementItems> Items { get; set; }
    }

    /// <summary>
    /// One of the data items held within a snapshot of time
    /// </summary>
    public struct ElementItems
    {
        public string Label { get; set; }
        public float Data { get; set; }
    }
}
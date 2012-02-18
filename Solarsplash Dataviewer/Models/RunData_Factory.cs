using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solarsplash_Dataviewer.Models
{
    public class RunData_Factory
    {
        public static RunData get(string RunName, List<string> RunLabels)
        {
            RunData tempRun = new RunData();
            tempRun.Name = RunName;
            tempRun.DataLabels = RunElements.DataLabel.MakeRange(RunLabels);
            return tempRun;
        }
    }
}
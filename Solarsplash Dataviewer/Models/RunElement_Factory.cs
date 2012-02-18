using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solarsplash_Dataviewer.Models
{
    static public class RunElement_Factory
    {
        public static RunElement get(int RunNumber, List<string> Data)
        {
            List<float> _Data = new List<float>();
            foreach (string item in Data)
            {
                _Data.Add(Convert.ToSingle(item));
            }
            return new RunElement(_Data, RunNumber);
        }
    }
}
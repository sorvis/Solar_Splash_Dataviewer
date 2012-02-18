using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solarsplash_Dataviewer.Models
{
    public class POST_RunWrapper
    {
        public string _RunName;
        public string RunName { get { return _RunName; } }

        public List<float> _Data;
        public int _RunNumber;

        public POST_RunWrapper(string RunName, List<string> Data, int RunNumber)
        {
            _RunName = RunName;

            _Data = new List<float>();
            foreach (string item in Data)
            {
                _Data.Add(Convert.ToSingle(item));
            }

            _RunNumber = RunNumber;
        }

        public RunElement getDataObject()
        {
            return new RunElement(_Data, _RunNumber);
        }
    }
}
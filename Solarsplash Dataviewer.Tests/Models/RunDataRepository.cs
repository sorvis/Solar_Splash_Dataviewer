using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Solarsplash_Dataviewer.Models;

namespace Solarsplash_Dataviewer.Tests.Models
{
    class RunDataRepository:Solarsplash_Dataviewer.Models.IRunDataRepository
    {
        private List<RunData> _db = new List<RunData>();

        public Exception ExceptionToThrow { get; set; }

        public bool Add_RunElement_to_RunData(string name, RunElement element)
        {
            bool found_matching_run = false;
            foreach (RunData item in _db)
            {
                if (item.Name == name)
                {
                    item.Runs.Add(element);
                    found_matching_run = true;
                }
            }

            if (!found_matching_run)
            {
                RunData temp = new RunData();
                temp.Name = name;
                temp.Runs.Add(element);
                _db.Add(temp);
                found_matching_run = true;
            }
            return found_matching_run;
        }

        public bool Delete_RunData_object(Solarsplash_Dataviewer.Models.RunData item)
        {
            return _db.Remove(item);
        }

        /// <summary>
        /// Not fully like real database since it does return the full object not just the base.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Solarsplash_Dataviewer.Models.RunData Get_RunData_base_object(string name)
        {
            return Get_RunData_object(name);
        }

        public Solarsplash_Dataviewer.Models.RunData Get_RunData_object(string name)
        {
            foreach (RunData item in _db)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }


        public void Add_New_Run(string name, List<Solarsplash_Dataviewer.Models.RunElements.DataLabel> labels)
        {
            if (Get_RunData_object(name) != null)
            {
                Add_New_Run(name + "_DUP", labels);
                return;
            }
            RunData temp = new RunData();
            temp.Name=name;
            temp.DataLabels.AddRange(labels);
            _db.Add(temp);
        }
    }
}

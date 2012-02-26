using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solarsplash_Dataviewer.Models
{
    public class EF_RunDataRepository:IRunDataRepository
    {
        private SolarsplashEntities _db;

        public EF_RunDataRepository() { _db = new SolarsplashEntities(); }
        public EF_RunDataRepository(SolarsplashEntities db){_db = db;}

        public RunData Get_RunData_object(string name)
        {
            return _db.RunData.Include("DataLabels").Include("Runs").Include("Runs.Data").FirstOrDefault(d => d.Name == name);
        }

        public RunData Get_RunData_base_object(string name)
        {
            return _db.RunData.Include("DataLabels").FirstOrDefault(d => d.Name == name);
        }

        public bool Delete_RunData_object(RunData item)
        {
            _db.RunData.Remove(item);
            _db.SaveChanges();
            return true;
        }

        public bool Add_RunElement_to_RunData(string name, RunElement element)
        {
            RunData temp = Get_RunData_object(name);
            temp.Runs.Add(element);
            _db.SaveChanges();
            return true;
        }

        public void Add_New_Run(string name, List<RunElements.DataLabel> labels)
        {
            if (Get_RunData_base_object(name) != null)
            {
                Add_New_Run(name + "_DUP", labels);
                return;
            }
            RunData temp = new RunData();
            temp.Name = name;
            temp.DataLabels.AddRange(labels);
            _db.RunData.Add(temp);
            _db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Solarsplash_Dataviewer.Models
{
    public class EF_RunDataRepository:IRunDataRepository
    {
        private SolarsplashEntities _db;

        public EF_RunDataRepository() { _db = new SolarsplashEntities(); }
        public EF_RunDataRepository(bool test_environment)
        {
            _db = new SolarsplashEntities();
            if (test_environment)
            {
                db_test_environment_setup();
            }
        }
        public EF_RunDataRepository(SolarsplashEntities db, bool test_environment) 
        { 
            _db = db;
            if (test_environment)
            {
                db_test_environment_setup();
            }
        }
        private void db_test_environment_setup() //very much test code not for production use
        {
            //Database.SetInitializer<SolarsplashEntities>(new DropCreateDatabaseIfModelChanges<SolarsplashEntities>());
            Database.SetInitializer<SolarsplashEntities>(new DropCreateDatabaseAlways<SolarsplashEntities>());
            _db.Database.Initialize(true);
        }

        public RunData Get_RunData_Analyers_and_DataLabels(int id)
        {
            return _db.RunData
                .Include("DataLabels")
                .Include("DataLabels.Analyzers")
                .FirstOrDefault(d => d.id_RunData == id);
        }

        public RunData Get_RunData_object(string name)
        {
            return _db.RunData
                .Include("DataLabels")
                .Include("DataLabels.Analyzers")
                .Include("Runs")
                .Include("Runs.Data")
                .FirstOrDefault(d => d.Name == name);
        }

        public RunData Get_RunData_base_object(string name)
        {
            return _db.RunData.Include("DataLabels").FirstOrDefault(d => d.Name == name);
        }

        private RunData Get_RunData_By_ID(int id)
        {
            return _db.RunData.Find(id);
        }

        public bool Delete_RunData_object(RunData item)
        {
            return Delete_RunData_object(item.Name);
        }
        public bool Delete_RunData_object(string name)
        {
            _db.RunData.Remove(Get_RunData_base_object(name));
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
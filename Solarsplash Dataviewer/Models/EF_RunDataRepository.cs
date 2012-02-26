using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solarsplash_Dataviewer.Models
{
    public class EF_RunDataRepository:IRunDataRepository
    {
        private SolarsplashEntities _db = new SolarsplashEntities();

        public RunData Get_RunData_object(string name)
        {
            throw new NotImplementedException();
        }

        public RunData Get_RunData_base_object(string name)
        {
            throw new NotImplementedException();
        }

        public bool Delete_RunData_object(RunData item)
        {
            throw new NotImplementedException();
        }

        public bool Add_RunElement_to_RunData(string name, RunElement element)
        {
            throw new NotImplementedException();
        }
    }
}
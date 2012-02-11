using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Solarsplash_Dataviewer.Models
{
    public class SolarsplashEntities:DbContext
    {
        public DbSet<DataLabelDefinition> DataLabelDefinition { get; set; }
        public DbSet<RunData> RunData { get; set; }
        public DbSet<RunElement> RunElement { get; set; }
        public DbSet<RunElements.DataLabel> DataLabel { get; set; }
    }
}
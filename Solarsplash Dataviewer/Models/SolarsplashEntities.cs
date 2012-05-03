using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Models
{
    public class SolarsplashEntities:DbContext
    {
        public DbSet<DataLabelDefinition> DataLabelDefinition { get; set; }
        public DbSet<RunData> RunData { get; set; }
        public DbSet<RunElement> RunElement { get; set; }
        public DbSet<RunElements.DataLabel> DataLabel { get; set; }
        public DbSet<RunElements.Data> Data { get; set; }
        public DbSet<DataAnalysis.Analyzer> Analyzer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RunData>()
                .HasMany(t => t.DataLabels)
                .WithOptional(p => p.RunData)
                .Map(c => c.MapKey("id_RunData"))
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RunData>()
                .HasMany(t => t.Runs)
                .WithOptional(p => p.RunData)
                .Map(c => c.MapKey("id_RunData"))
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<DataLabel>()
                .HasMany(t=>t.Analyzers)
                .WithOptional(t => t.DataLabel)
                .Map(c => c.MapKey("id_DataLabel"))
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<RunElement>()
                .HasMany(t => t.Data)
                .WithOptional(t => t.RunElement)
                .Map(c => c.MapKey("id_RunElement"))
                .WillCascadeOnDelete(true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Models.DataAnalysis
{
    public class Analyzer:IAnalyzer
    {
        [Key]
        public int id_analyzer { get; set; }
        public DataLabel DataLabel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private IAnalyzer _IAanlyzer;
        public Analyzer(IAnalyzer analyyzer_interface_object)
        {
            Name = analyyzer_interface_object.Name;
            Description = analyyzer_interface_object.Description;
            _IAanlyzer = analyyzer_interface_object;
        }
        public Analyzer()
        { }
        //public Analyzer(string name, string description)
        //{
        //    Name = name;
        //    Description = description;
        //}
        public IAnalyzer get_IAnalyzer()
        {
            if (_IAanlyzer != null)
            {
                return _IAanlyzer;
            }
            else
            {
                return (IAnalyzer)this;
            }
        }
    }
}
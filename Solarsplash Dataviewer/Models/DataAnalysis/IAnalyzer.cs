using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solarsplash_Dataviewer.Models.DataAnalysis
{
    public interface IAnalyzer
    {
        string Name {get; set;}
        string Description { get; set; }
    }
}

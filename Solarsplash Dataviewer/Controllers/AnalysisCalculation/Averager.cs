using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solarsplash_Dataviewer.Models;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Controllers.AnalysisCalculation
{
    public class Averager
    {
        private List<float> Data;
        public Averager(List<float> data)
        {
            Data = data;
        }
        public float getTotalAverage()
        {
            float sum = 0;
            foreach (float item in Data)
            {
                sum += item;
            }
            return sum / Data.Count;
        }
    }
}
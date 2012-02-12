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
        public float getLastFewAverage(int numberOfLastValues)
        {
            List<float> tempData = new List<float>();
            for (int i = Data.Count - 1; i >= 0 && i >= Data.Count - numberOfLastValues; i--)
            {
                tempData.Add(Data[i]);
            }
            return getAverage(tempData);
        }
        public float getTotalAverage()
        {
            return getAverage(Data);
        }
        private float getAverage(List<float> list)
        {
            return list.Sum() / list.Count;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solarsplash_Dataviewer.Models;
using Solarsplash_Dataviewer.Models.RunElements;
using Solarsplash_Dataviewer.Models.DataAnalysis;

namespace Solarsplash_Dataviewer.Controllers.Analysis_Factory.AnalysisCalculation
{
    public class Averager:IAnalyzer
    {
        public const string Type_Name = "Averager";
        public string Name { get; set; }
        public string Description { get; set; }
        private List<float> _Data;
        public Averager(List<float> data)
        {
            _Data = data;
        }
        public Averager(List<float> data, IAnalyzer analyzer)
        {
            _Data = data;
            Name = analyzer.Name;
            Description = analyzer.Description;
        }
        public float getLastFewAverage(int numberOfLastValues)
        {
            List<float> tempData = new List<float>();
            for (int i = _Data.Count - 1; i >= 0 && i >= _Data.Count - numberOfLastValues; i--)
            {
                tempData.Add(_Data[i]);
            }
            return getAverage(tempData);
        }
        public float getTotalAverage()
        {
            return getAverage(_Data);
        }
        private float getAverage(List<float> list)
        {
            return list.Sum() / list.Count;
        }
    }
}
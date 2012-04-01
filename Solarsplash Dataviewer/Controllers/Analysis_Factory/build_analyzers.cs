using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solarsplash_Dataviewer.Models;
using Solarsplash_Dataviewer.Models.RunElements;
using Solarsplash_Dataviewer.Models.DataAnalysis;
using Solarsplash_Dataviewer.Controllers.Analysis_Factory.AnalysisCalculation;

namespace Solarsplash_Dataviewer.Controllers.Analysis_Factory
{
    public static class build_analyzers
    {
        /// <summary>
        /// Populate RunData labels with IAnalyzers that contain data and ability to do calculations
        /// </summary>
        /// <param name="run"></param>
        /// <returns></returns>
        public static RunData build(RunData run)
        {
            DataExtractor data;
            foreach (DataLabel label in run.DataLabels)
            {
                data = new DataExtractor(run, label.LabelName);
                for (int i = 0; i < label.Analyzers.Count; i++)
                {
                    label.Analyzers[i] = new Analyzer(factory(label.Analyzers[i], data.Data));
                }
            }
            return run;
        }
        private static IAnalyzer factory(IAnalyzer analyzer, List<float> data_float)
        {
            switch (analyzer.Name)
            {
                case Averager.Type_Name:
                    return new Averager(data_float, analyzer);
                    //break;
                default:    // found no known type for that name
                    return analyzer;
            }
        }
    }
}
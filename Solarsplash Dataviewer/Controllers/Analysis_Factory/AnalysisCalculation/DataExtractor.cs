using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solarsplash_Dataviewer.Models;
using Solarsplash_Dataviewer.Models.RunElements;

namespace Solarsplash_Dataviewer.Controllers.Analysis_Factory.AnalysisCalculation
{
    /// <summary>
    /// Converts a RunData object into data for a particual element across the points of time
    /// </summary>
    public class DataExtractor
    {
        private RunData _run { get; set; }
        public List<float> Data { get; set; }
        private string _dataLabel;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="runData">Whole data object</param>
        /// <param name="dataLabel">Label of data interested in</param>
        public DataExtractor(RunData runData, string dataLabel)
        {
            _run = runData;
            _dataLabel = dataLabel;
            Data = extractData(getDataPosition());
        }
        /// <summary>
        /// Converts runData object into float values of a particualar data item
        /// </summary>
        /// <param name="dataPosition">position in array of data</param>
        /// <returns></returns>
        private List<float> extractData(int dataPosition)
        {
            List<float> tempList = new List<float>();
            foreach (RunElement element in _run.Runs)
            {
                tempList.Add(element.Data[dataPosition].Value);
            }
            return tempList;
        }
        private int getDataPosition()
        {
            int index = 0;
            foreach (DataLabel label in _run.DataLabels)
            {
                if (label.LabelName == _dataLabel)
                {
                    return index;
                }
                index++;
            }
            // did not find a Label in the list of labels something went wrong -- this should never happen
            throw new System.ArgumentException("Label not found in runData", "Label");
        }
    }
}
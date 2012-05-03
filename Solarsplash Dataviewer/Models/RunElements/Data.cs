using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Solarsplash_Dataviewer.Models.RunElements
{
    public class Data
    {
        [Key]
        public int id_Data { get; set; }
        public float Value { get; set; }
        public RunElement RunElement { get; set; }
        public Data()
        {
        }
        public Data(float data)
        {
            Value = data;
        }
        public static List<Data> MakeRange(List<float> items)
        {
            List<Data> tempList = new List<Data>();
            foreach (float item in items)
            {
                tempList.Add(new Data(item));
            }
            return tempList;
        }
    }
}
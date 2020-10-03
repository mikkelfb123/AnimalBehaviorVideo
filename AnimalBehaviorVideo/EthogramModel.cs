using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalBehaviorVideo
{
    public class EthogramModel
    {
        public string Name { get; set; }
        public string BorderColor { get; set; }
        public bool active { get; set; }

        public EthogramModel()
        {
            BorderColor = "#800000";
        }

        public List<double> StartTime = new List<double>();
        public List<double> EndTime = new List<double>();




        public void addStartTime(double time)
        {
            StartTime.Add(time);
        }

        public void addEndTime(double time)
        {
            EndTime.Add(time);
        }


    }
}

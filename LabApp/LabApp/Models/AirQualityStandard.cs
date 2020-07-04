using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp.Models
{
    public class AirQualityStandard
    {
        public string Name { get; set; }
        public string Pollutant { get; set; }
        public double Limit { get; set; }
        public double Percent { get; set; }
        public string Averaging { get; set; }
    }
}

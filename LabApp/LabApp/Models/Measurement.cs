using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp.Models
{
    public class Measurement
    {
        public int CurrentDisplayValue { get; set; }
        public MeasurementItem Current { get; set; }
        public MeasurementItem[] History { get; set; }
        public MeasurementItem[] Forecast { get; set; }
        public Installation Installation { get; set; }
    }
}

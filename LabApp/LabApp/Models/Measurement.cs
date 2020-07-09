using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LabApp.Models
{
    public class Measurement
    {
        public int CurrentDisplayValue { get; set; }
        public MeasurementItem Current { get; set; }
        public MeasurementItem[] History { get; set; }
        public MeasurementItem[] Forecast { get; set; }
        public Installation Installation { get; set; }

        public Measurement()
        {

        }

        public Measurement(MeasurementEntity measurementEntity, Installation installation, MeasurementItem measurementItem)
        {
            CurrentDisplayValue = measurementEntity.CurrentDisplayValue;
            Current = measurementItem;
            History = JsonConvert.DeserializeObject<MeasurementItem[]>(measurementEntity.History);
            Forecast = JsonConvert.DeserializeObject<MeasurementItem[]>(measurementEntity.Forecast);
            Installation = installation;
        }
    }
}

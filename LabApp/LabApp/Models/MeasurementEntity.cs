using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Newtonsoft.Json;

namespace LabApp.Models
{
    public class MeasurementEntity
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CurrentDisplayValue { get; set; }
        public int CurrentId { get; set; }
        public string History { get; set; }
        public string Forecast { get; set; }
        public int InstallationId { get; set; }

        public MeasurementEntity(Measurement measurement, MeasurementItemEntity current)
        {
            this.CurrentDisplayValue = measurement.CurrentDisplayValue;
            this.CurrentId = current.Id;
            this.History = JsonConvert.SerializeObject(measurement.History);
            this.Forecast = JsonConvert.SerializeObject(measurement.Forecast);
            this.InstallationId = measurement.Installation.Id;

        }
        public MeasurementEntity()
        {

        }

    }
}

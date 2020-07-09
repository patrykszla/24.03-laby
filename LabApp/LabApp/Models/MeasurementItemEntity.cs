using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Newtonsoft.Json;

namespace LabApp.Models
{
    public class MeasurementItemEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public string Values { get; set; }
        public string Indexes { get; set; }
        public string Standards { get; set; }


        public MeasurementItemEntity(MeasurementItem measurementEntity)
        {
            this.FromDateTime = measurementEntity.FromDateTime;
            this.TillDateTime = measurementEntity.TillDateTime;
            this.Values = JsonConvert.SerializeObject(measurementEntity.Values);
            this.Indexes = JsonConvert.SerializeObject(measurementEntity.Indexes);
            this.Standards = JsonConvert.SerializeObject(measurementEntity.Standards);
        }
        public MeasurementItemEntity()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp.Models
{
    public class MeasurementItem
    {
        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public MeasurementValue[] Values { get; set; }
        public AirQualityIndex[] Indexes { get; set; }
        public AirQualityStandard[] Standards { get; set; }

        public MeasurementItem()
        {

        }

        public MeasurementItem(MeasurementItem measurementItem)
        {
            this.FromDateTime = measurementItem.FromDateTime;
            this.TillDateTime = measurementItem.TillDateTime;
            this.Values = measurementItem.Values;
            this.Indexes = measurementItem.Indexes;
            this.Standards = measurementItem.Standards;

        }

        public MeasurementItem(MeasurementItemEntity measurementItemEntity, MeasurementValue[] values, AirQualityIndex[] indexes, AirQualityStandard[] standards)
        {
            FromDateTime = measurementItemEntity.FromDateTime;
            TillDateTime = measurementItemEntity.TillDateTime;
            Values = values;
            Indexes = indexes;
            Standards = standards;
        }
    }
}

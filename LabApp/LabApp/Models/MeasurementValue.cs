using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LabApp.Models
{
    public class MeasurementValue
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public MeasurementValue()
        {

        }
    }
}

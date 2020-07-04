using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using LabApp.Models;

namespace LabApp.ViewModels
{

    class DetailsViewModel : BaseViewModel
    {
        

        public DetailsViewModel()
        {

        }

        private Measurement item;
        
        public Measurement Item
        {
            get => item;
            set
            {
                SetProperty(ref item, value);

                refreshData();
            }
        }

        private void refreshData()
        {
            if (Item?.Current == null) return;
            var current = Item?.Current;
            var index = current.Indexes?.FirstOrDefault(c => c.Name == "AIRLY_CAQI");
            var values = current.Values;
            var standards = current.Standards;

            CaqiValue = (int)Math.Round(index?.Value ?? 0);
            Caqititle = index.Description;
            CaqiDescription = index.Advice;
            Pm25Value = (int)Math.Round(values?.FirstOrDefault(s => s.Name == "PM25")?.Value ?? 0);
            Pm10Value = (int)Math.Round(values?.FirstOrDefault(s => s.Name == "PM10")?.Value ?? 0);
            HumidityValue = (int)Math.Round(values?.FirstOrDefault(s => s.Name == "HUMIDITY")?.Value ?? 0);
            PressureValue = (int)Math.Round(values?.FirstOrDefault(s => s.Name == "PRESSURE")?.Value ?? 0);
            Pm25Percent = (int)Math.Round(standards?.FirstOrDefault(s => s.Pollutant == "PM25")?.Percent ?? 0);
            Pm10Percent = (int)Math.Round(standards?.FirstOrDefault(s => s.Pollutant == "PM10")?.Percent ?? 0);

        }





        private int caqiValue = 57;
        public int CaqiValue
        {
            get => caqiValue;
            set => SetProperty(ref caqiValue, value);
        }
        private string caqiTitle = "Świetna jakość!";
        public string Caqititle
        {
            get => caqiTitle;
            set => SetProperty(ref caqiTitle, value);
        }
        private string caqiDescription = "Możesz bezpiecznie wyjść bez swojej maski anty-smogowej i nie bać sie o swoje zdrowie.";
        public string CaqiDescription
        {
            get => caqiDescription;
            set => SetProperty(ref caqiDescription, value);
        }
        private int pm25Value = 34;
        public int Pm25Value
        {
            get => pm25Value;
            set => SetProperty(ref pm25Value, value);
        }

        private int pm25Percent = 137;
        public int Pm25Percent
        {
            get => pm25Percent;
            set => SetProperty(ref pm25Percent, value);
        }

        private int pm10Value = 67;
        public int Pm10Value
        {
            get => pm10Value;
            set => SetProperty(ref pm10Value, value);
        }

        private int pm10Percent = 135;
        public int Pm10Percent
        {
            get => pm10Percent;
            set => SetProperty(ref pm10Percent, value);
        }

        private double humidityValue = 0.95;
        public double HumidityValue
        {
            get => humidityValue;
            set => SetProperty(ref humidityValue, value);
        }

        private int pressureValue = 1027;
        public int PressureValue
        {
            get => pressureValue;
            set => SetProperty(ref pressureValue, value);
        }

    }
}
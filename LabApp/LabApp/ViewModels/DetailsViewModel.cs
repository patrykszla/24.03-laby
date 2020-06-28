using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LabApp.ViewModels
{

    class DetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DetailsViewModel()
        {

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

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;

            RaisePropertyChanged(propertyName);

            return true;
        }
    }
}
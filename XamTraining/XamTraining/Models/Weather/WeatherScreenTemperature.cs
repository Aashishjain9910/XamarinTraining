using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamTraining.Models.Weather
{
    class WeatherScreenTemperature : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Day
        {
            get;
            set;
        }
        public string WeatherImage
        {
            get;
            set;
        }
        public string MaxTemperature
        {
            get;
            set;
        }
        public string MinTemperature
        {
            get;
            set;
        }
        public string CurrentDayTime
        {
            get;
            set;
        }
        public string Temperature
        {
            get;
            set;
        }


    }
}

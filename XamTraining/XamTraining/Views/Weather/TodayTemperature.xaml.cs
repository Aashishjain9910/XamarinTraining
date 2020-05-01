using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Models.Weather;

namespace XamTraining.Views.Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayTemperature : ContentPage
    {
        List<WeatherScreenTemperature> dailyWeather;
        List<WeatherScreenTemperature> currentDayWeather;

        public TodayTemperature()
        {
            InitializeComponent();

            currentDayWeather = new List<WeatherScreenTemperature>
            {
                new WeatherScreenTemperature
                {
                    CurrentDayTime="now",
                    WeatherImage="Sun.png",
                    Temperature="20°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="12",
                    WeatherImage="Sun.png",
                    Temperature="22°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="13",
                    WeatherImage="Sun.png",
                    Temperature="22°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="14",
                    WeatherImage="Sun.png",
                    Temperature="22°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="15",
                    WeatherImage="Sun.png",
                    Temperature="23°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="16",
                    WeatherImage="Sun.png",
                    Temperature="22°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="17",
                    WeatherImage="Sun.png",
                    Temperature="21°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="18",
                    WeatherImage="Sun.png",
                    Temperature="21°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="19",
                    WeatherImage="Windy.png",
                    Temperature="20°"

                },
                new WeatherScreenTemperature
                {
                    CurrentDayTime="20",
                    WeatherImage="Windy.png",
                    Temperature="20°"

                },

            };

            currentDayWeatherList.ItemsSource = currentDayWeather;



            //last block list
            dailyWeather = new List<WeatherScreenTemperature>
            {
                new WeatherScreenTemperature
                {
                    Day="Friday",
                    WeatherImage="Sun.png",
                    MaxTemperature="28°",
                    MinTemperature="15°"
                },
                new WeatherScreenTemperature
                {
                    Day="Saturday",
                    WeatherImage="Sun.png",
                    MaxTemperature="34°",
                    MinTemperature="21°"
                },
                new WeatherScreenTemperature
                {
                    Day="Sunday",
                    WeatherImage="Windy.png",
                    MaxTemperature="29°",
                    MinTemperature="14°"
                },
                new WeatherScreenTemperature
                {
                    Day="Monday",
                    WeatherImage="Sun.png",
                    MaxTemperature="24°",
                    MinTemperature="12°"
                },
                new WeatherScreenTemperature
                {
                    Day="Tuesday",
                    WeatherImage="Sun.png",
                    MaxTemperature="19°",
                    MinTemperature="13°"
                },
                new WeatherScreenTemperature
                {
                    Day="Wednesday",
                    WeatherImage="PartlyCloudy.png",
                    MaxTemperature="23°",
                    MinTemperature="16°"
                }
                
            };
            daywiseList.ItemsSource = dailyWeather;


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Models;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeToListView : ContentPage
    {
        public WelcomeToListView()
        {
            InitializeComponent();

            List<WeatherList> tempList = new List<WeatherList>
            {
                new WeatherList
                {
                    Place="Berlin", Temperature="0 C",Weather="Snowing", WeatherImage="snowing.png"
                },
                new WeatherList
                {
                    Place="Banglore", Temperature="23 C",Weather="Thunderstorms", WeatherImage="thunderstorm.png"
                },
                new WeatherList
                {
                    Place="London", Temperature="5 C",Weather="Raining", WeatherImage="raining.png"
                },
                new WeatherList
                {
                    Place="New York", Temperature="18 C",Weather="Cloudy", WeatherImage="cloudy.png"
                },
                new WeatherList
                {
                    Place="Sydney", Temperature="32 C",Weather="Sunny", WeatherImage="sunny.png"
                }
            };
            //testingListView.ItemsSource = tempList;
            BindableLayout.SetItemsSource(bind,tempList);
        }


        private void testingListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DisplayAlert("Message", "Item is selected", "OK");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<WeatherList> tempList ;
        
        public WelcomeToListView()
        {
            InitializeComponent();
            tempList= new ObservableCollection<WeatherList>
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
            testingListView.ItemsSource = tempList;
           // BindableLayout.SetItemsSource(bind,tempList);
        }


        private void testingListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DisplayAlert("Message", "Item is selected", "OK");
        }

        private void AddWeatherDetails(object sender, EventArgs e)
        {
            var addPlace = adPlace.Text;
            var addWeather = adWeather.Text;
            var addTemperature = adTemperature.Text;

            tempList.Add(new WeatherList { Place=addPlace,Weather= addWeather , Temperature = addTemperature });
        }

        private void RemoveWeatherDetails(object sender, EventArgs e)
        {
                var DelPlace = adPlace.Text;
                var DelWeather = adWeather.Text;
                var DelTemp = adTemperature.Text;

                int i = 0, deleteIndex = -1;

                foreach (var item in tempList)
                {
                    if (item.Place == DelPlace)
                    {
                        deleteIndex = i;
                    }

                    i++;
                }

                tempList.RemoveAt(deleteIndex);
        
        }

        private void MenuItem_Delete(object sender, EventArgs e)
        {
            var deleteItem = (sender as MenuItem).CommandParameter as WeatherList;
            tempList.Remove(deleteItem);
        }

        private void MenuItem_Edit(object sender, EventArgs e)
        {
            var editItem = ((MenuItem)sender);
            DisplayAlert("Edit", editItem.CommandParameter.ToString(), "Ok");
        }

        private void testingListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
        }
    }
}
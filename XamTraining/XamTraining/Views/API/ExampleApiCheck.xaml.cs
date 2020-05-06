using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamTraining.Views.API
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExampleApiCheck : ContentPage
    {
        public ExampleApiCheck()
        {
            InitializeComponent();
            GetList();

        }

        IList<Example> exam;
        
        async void GetList()
        {
            
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://samples.openweathermap.org/data/2.5/forecast/daily?id=524901&appid=b1b15e88fa797225412429c1c50c122a1");
            var data = JsonConvert.DeserializeObject<Example>(response);
            colList.ItemsSource = data.list;

        }
    }

    public class City
    {
        public int geoname_id { get; set; }
        public string name { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string country { get; set; }
        public string iso2 { get; set; }
        public string type { get; set; }
        public int population { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public Temp temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public IList<Weather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public double snow { get; set; }
    }

    public class Example
    {
        public string cod { get; set; }
        public int message { get; set; }
        public City city { get; set; }
        public int cnt { get; set; }
        public IList<List> list { get; set; }
    }



}
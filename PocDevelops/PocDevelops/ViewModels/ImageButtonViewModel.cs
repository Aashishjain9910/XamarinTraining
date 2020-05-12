using PocDevelops.Activity_Indicator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocDevelops.Buttons
{
    public class ImageButtonViewModel 
    {
        
        public ICommand MyCommand { get; set;}
        public ImageButtonViewModel()
        {
            MyCommand = new Command(button_click);
        }
        public void button_click()
        {
            //App.Current.MainPage.DisplayAlert("ok", "okkkkk", "ok");
            App.Current.MainPage.Navigation.PushAsync(new ActivityIndicatorPage());
        }
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Views;

namespace XamTraining
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new SigninView());
        }

        async protected override void OnStart()
        {
            await MainPage.DisplayAlert("Alert", "This is the OnStart Alert", "OK");
        }

        async protected override void OnSleep()
        {
            await MainPage.DisplayAlert("Alert", "This is the OnSleep Alert", "OK");
        }

        async protected override void OnResume()
        {
            await MainPage.DisplayAlert("Alert", "This is the OnResume Alert", "OK");
        }
    }
}

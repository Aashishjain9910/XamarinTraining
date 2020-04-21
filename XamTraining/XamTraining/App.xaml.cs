using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace XamTraining
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new ProfileDetailPage());
        }

        async protected override void OnStart()
        {
            AppCenter.Start("android=fd8e2417-b900-462b-801f-be16be7ab7f7;",
                  typeof(Analytics), typeof(Crashes));
 
            await MainPage.DisplayAlert("           Successive Technologies", "                        Welcomes You", "Continue");
        }

        async protected override void OnSleep()
        {
            await MainPage.DisplayAlert("Alert", "This was the OnSleep Alert", "OK");
        }

        async protected override void OnResume()
        {
            await MainPage.DisplayAlert("Alert", "This is the OnResume Alert", "OK");
        }
    }
}

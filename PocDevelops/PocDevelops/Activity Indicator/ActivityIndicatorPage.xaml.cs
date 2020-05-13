using PocDevelops.Activity_Indicator.Loaders;
using PocDevelops.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocDevelops.Activity_Indicator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityIndicatorPage : ContentPage
    {
        public ActivityIndicatorPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            // this is used for first loader
            OneArc oneArcPage = new OneArc();
            SingleArc.Content = oneArcPage;



            // this is used for second loader
            TwoSepareteArcs twoSeparateArcPage = new TwoSepareteArcs();
            TwoSeparateArcsContentView.Content = twoSeparateArcPage;



            // this is used for third loader
            PendulumLoader pendulumLoaderPage = new PendulumLoader();
            PendulumLoaderContentView.Content = pendulumLoaderPage;

            
            
            // This is used for fourth loader
            BouncingLoader bouncingLoaderPage = new BouncingLoader();
            BouncingLoaderContentView.Content = bouncingLoaderPage;

        }
       
    }
}
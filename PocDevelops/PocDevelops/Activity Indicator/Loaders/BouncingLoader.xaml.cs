using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocDevelops.Activity_Indicator.Loaders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BouncingLoader : ContentView
    {
        public BouncingLoader()
        {
            InitializeComponent();
            OnAppearing();
        }


        protected async void OnAppearing()
        {
            int i = 2;
            while (i == 2)
            {
                await box1.TranslateTo(0, -40, 2000, Easing.BounceIn);
                await box1.TranslateTo(0, 0, 1000);

                await box2.TranslateTo(0, -40, 2000, Easing.BounceIn);
                await box2.TranslateTo(0, 0, 1000);

                await box3.TranslateTo(0, -40, 2000, Easing.BounceIn);
                await box3.TranslateTo(0, 0, 1000);

                await box4.TranslateTo(0, -40, 2000, Easing.BounceIn);
                await box4.TranslateTo(0, 0, 1000);
            }


        }
    }
}
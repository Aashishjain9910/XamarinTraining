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
    public partial class PendulumLoader : ContentView
    {
        public PendulumLoader()
        {
            InitializeComponent();
            OnAppearing();
        }

        protected async void OnAppearing()
        {
            int i = 2;
            while (i == 2)
            {
                await updown.TranslateTo(-20, -10, 600, Easing.SinInOut);
                await updown.TranslateTo(0, 0, 600);

                await updown3.TranslateTo(20, -10, 600, Easing.SinInOut);
                await updown3.TranslateTo(0, 0, 600);
            }


        }
    }
}
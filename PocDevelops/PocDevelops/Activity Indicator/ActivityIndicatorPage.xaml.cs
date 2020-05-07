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

            

            //OneArc content1 = new OneArc();
            //OneArcsContentView.Content = content1;


            //TwoSepareteArcs content2 = new TwoSepareteArcs();
            //TwoSeparateArcsContentView.Content = content2;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            OneArc oneArcPage = new OneArc();
            SingleArc.Content = oneArcPage;

            TwoSepareteArcs twoSeparateArcPage = new TwoSepareteArcs();
            TwoSeparateArcsContentView.Content = twoSeparateArcPage;

            

        }


       

        private async void bouncein(object sender, EventArgs e)
        {
            await SingleArc.TranslateTo(0, -50, 4000, Easing.BounceIn);
            await SingleArc.TranslateTo(0, 0, 2000);
            await SingleArc.TranslateTo(0, 50, 4000, Easing.BounceOut);
            await SingleArc.TranslateTo(0, 0, 2000);
        }

        private async void load(object sender, EventArgs e)
        {
            int i = 2;
            while (i == 2)
            {
                await updown.TranslateTo(0, -20, 200);
                await updown.TranslateTo(0, 0, 200);
                await updown1.TranslateTo(0, -20, 200);
                await updown1.TranslateTo(0, 0, 200);
                await updown2.TranslateTo(0, -20, 200);
                await updown2.TranslateTo(0, 0, 200);
                await updown3.TranslateTo(0, -20, 200);
                await updown3.TranslateTo(0, 0, 200);
            }
        }
    }
}
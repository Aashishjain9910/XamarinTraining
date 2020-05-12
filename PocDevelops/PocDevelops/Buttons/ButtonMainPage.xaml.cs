using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocDevelops.Buttons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonMainPage : ContentPage
    {
        public ButtonMainPage()
        {
            BindingContext = new ImageButtonViewModel();
            InitializeComponent();
        }

        private async void ImageButtons_Clicked(object sender, EventArgs e)
        {
            customIB.Opacity = 0;
            await customIB.FadeTo(1, 300);
            await customIB.ScaleTo(1.05, 500);
            await customIB.ScaleTo(1, 500);
        }
    }
}
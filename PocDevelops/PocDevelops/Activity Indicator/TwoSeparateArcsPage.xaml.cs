using PocDevelops.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocDevelops
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwoSeparateArcsPage : ContentPage
    {
        public TwoSeparateArcsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TwoSepareteArcs page = new TwoSepareteArcs();
            TwoSeparateArcsContentView.Content = page;
        }
    }
}
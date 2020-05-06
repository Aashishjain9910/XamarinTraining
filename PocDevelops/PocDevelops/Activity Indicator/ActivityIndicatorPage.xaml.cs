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

            OneArc content1 = new OneArc();
            OneArcsContentView.Content = content1;


            TwoSepareteArcs content4 = new TwoSepareteArcs();
            TwoSeparateArcsContentView.Content = content4;
        }
    }
}
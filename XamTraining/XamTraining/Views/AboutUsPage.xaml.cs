using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUsPage : ContentPage
    {
        public AboutUsPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int temp = Convert.ToInt32(btn.CommandParameter);
            switch(temp)
            {
                case 1: aboutUsContentView.Content = new RequirementAnalysisContentView();
                    break;

                case 2: aboutUsContentView.Content = new UIUXStudioContentView();
                    break;

                case 3: aboutUsContentView.Content = new NextGenContentView();
                    break;

                case 4:
                    aboutUsContentView.Content = new QualityAnalysisContentView();
                    break;

                case 5:
                    aboutUsContentView.Content = new DeploySupportContentView();
                    break;

            }
        }
    }
}
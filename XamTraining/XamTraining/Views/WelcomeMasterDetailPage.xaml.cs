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
    public partial class WelcomeMasterDetailPage : MasterDetailPage
    {
        public WelcomeMasterDetailPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new WelcomeTabbedPage());
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new WelcomeCarouselPage());
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new WelcomeTemplatedPage());
        }
    }
}
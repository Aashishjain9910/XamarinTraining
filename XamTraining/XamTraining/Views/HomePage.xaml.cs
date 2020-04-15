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
    public partial class HomePage : MasterDetailPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int temp = Convert.ToInt32(btn.CommandParameter);
            switch(temp)
            {
                case 1:
                    Detail = new NavigationPage(new HomePage());
                    break;

                case 2:
                    Detail = new NavigationPage(new LoginPage());
                    break;

                case 3:
                    Detail = new NavigationPage(new AboutUsPage());
                    break;

                case 4:
                    Detail = new NavigationPage(new WelcomeTabbedPage());
                    break;

                case 5:
                    Detail = new NavigationPage(new WelcomeToListView());
                    break;
                
                case 6:
                    Detail = new NavigationPage(new WelcomeCarouselPage());
                    break;
                
                case 7:
                    Detail = new NavigationPage(new BlogsCollectionView());
                    break;
                
                case 8:
                    Detail = new Page2();
                    break;
                
                case 9:
                    Detail = new NavigationPage(new NewRegistration());
                    break;

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTraining
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var mail = "as";
            var paswd = "12";

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (email.Text == mail && pswd.Text == paswd)
            {

                DisplayAlert("Alert", "Sign In failed", "OK");
            }

            else
            {
                DisplayAlert("Alert", "Sign In Successful", "OK");
            }
        }

        private void Entry_Completed1(object sender, EventArgs e)
        {

        }
    }
}

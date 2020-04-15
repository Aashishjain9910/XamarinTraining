using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Models;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        LoginModel loginModel = new LoginModel();
        public LoginPage()
        {

            InitializeComponent();
            loginModel.Show += Model_Show;
            BindingContext = loginModel;
        }

        private void Model_Show(object sender, EventArgs e)
        {
            var str = (string)sender;
            App.Current.MainPage.DisplayAlert("Error", str, "OK");
        }

    }
}
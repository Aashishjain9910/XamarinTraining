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
    public partial class SigninView : ContentPage
    {

        SigninModel signinModel = new SigninModel();
        public SigninView()
        {

            InitializeComponent();
            signinModel.Show += Model_Show;
            BindingContext = signinModel;
        }

        private void Model_Show(object sender, EventArgs e)
        {
            var str = (string)sender;
            App.Current.MainPage.DisplayAlert("Error", str, "OK");
        }

    }
}
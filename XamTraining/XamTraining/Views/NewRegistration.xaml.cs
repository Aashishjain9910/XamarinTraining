using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Models;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRegistration : ContentPage
    {
        NewRegistrationModel registrationModel = new NewRegistrationModel();
        public NewRegistration()
        {
            InitializeComponent();
            registrationModel.Show += Register_Model;
            BindingContext = registrationModel;

        }

        private void Register_Model(object sender, EventArgs e)
        {
            var str = (string)sender;
            App.Current.MainPage.DisplayAlert("Error", str, "OK");
        }



    }
}
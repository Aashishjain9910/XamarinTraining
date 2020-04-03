using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamTraining
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        bool isValid;
        public void EmailCompleted(object sender, EventArgs e)
        {
            var inputEmail = "" + email.Text;
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            isValid = regex.IsMatch((inputEmail.ToString()).Trim());
            if (!isValid)
            {
                DisplayAlert("Error", "Please enter the valid email", "ok");
            }
            else
            {
                pswd.Focus();
            }
        }
        public void PswdCompleted(object sender, EventArgs e)
        {
            var inputPassword = "" + pswd.Text;

            if (inputPassword.Length == 0)
            {
                DisplayAlert("Error", "Please provide the password", "ok");
            }
            else
            {
                Signin.Focus();
            }
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            var emailCheck = "" + email.Text;
            var pswdCheck = "" + pswd.Text;
            var inputEmail = "" + email.Text;
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            isValid = regex.IsMatch((inputEmail.ToString()).Trim());
            if (emailCheck.Length == 0 || pswdCheck.Length == 0)
            {
                DisplayAlert("Error", "Enter all Details", "OK");
            }
            else if (!isValid)
            {
                DisplayAlert("Error", "Incorrect Email", "OK");
            }
            else
            {
                DisplayAlert("SignIn Attempted", "Successful", "OK");

            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            localEmailPath = Path.Combine(FileSystem.AppDataDirectory, localEmailFileName);
            localPasswordPath = Path.Combine(FileSystem.AppDataDirectory, localPasswordFileName);
            //localForgotPasswordPath = Path.Combine(FileSystem.AppDataDirectory, localForgotPasswordFile);
            //localSecurityAnswerPath = Path.Combine(FileSystem.AppDataDirectory, localSecurityAnswerFile);

        }

        private void Model_Show(object sender, EventArgs e)
        {
            var str = (string)sender;
            App.Current.MainPage.DisplayAlert("Error", str, "OK");
        }
        
        
        //Email and password file 
        const string localEmailFileName = "EmailFile.txt";
        const string localPasswordFileName = "PasswordFile.txt";
        
        string localEmailPath;
        string localPasswordPath;

        //forgotpassword files
        //const string localForgotPasswordFile = "ForgotPasswordFile.txt";
        //string localForgotPasswordPath;

        const string localSecurityAnswerFile = "SecurityAnswerFile.txt";
        string localSecurityAnswerPath;
        
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                File.WriteAllText(localEmailPath, mail.Text);
                File.WriteAllText(localPasswordPath, pswd.Text);
                //File.WriteAllText(localPasswordPath, SecurityAnswer.Text);

            }

        }

        //private void loadEmail(object sender, EventArgs e)
        //{
        //    EmailContext.Text = File.ReadAllText(localEmailPath);
        //    PassContext.Text = File.ReadAllText(localPasswordPath);
        //}

        private void Clicked_ForgotPassword(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ForgotPasswordVerificationPage());
        }

       

        private void CreateNewAccountButton(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewRegistration());
        }
    }
}
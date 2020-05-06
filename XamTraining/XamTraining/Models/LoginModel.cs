using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamTraining.Views;
using XamTraining.Views.Weather;

namespace XamTraining.Models
{
    public class LoginModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Show;
        public LoginModel()
        {
            //localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);

        }

        public string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        public string password;
        private bool isValid;
        public string Password
        {
            get {return password; }
            set 
            { 
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));

            }

        }
        public ICommand SubmitCommand
        {
            get
            {
                return new Command(OnSubmit);
            }
        }

        public void OnSubmit()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                Show?.Invoke("Please enter Email & Password", null);
            }
            else
            {
                var inputEmail = "" + Email;
                Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                isValid = regex.IsMatch((inputEmail.ToString()).Trim());
                if (!isValid)
                {
                    Show?.Invoke("Please enter the valid email", null);
                }
                else
                {
                    if(Email==email && Password == password)
                    {

                    SessionManager sm = new SessionManager();
                    sm.setUserLoggedIn();
                    App.Current.MainPage.Navigation.PushAsync(new TodayTemperature());
                    }


                }
            }
        }

        //public ICommand ForgotPasswordCommand
        //{
        //    get
        //    {
        //        return new Command(OnForgotPass);
        //    }
        //}

        //const string localFileName = "ForgotPasswordFile.txt";
        //string localPath;
        //public void OnForgotPass()
        //{
        //    File.WriteAllText(localPath, Email.Text);
        //}

    }
}

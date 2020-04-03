using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamTraining.Models
{
    public class SigninModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
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
        public string Password
        {
            get {return password; }
            set 
            { 
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));

            }

        }
        public ICommand SubmitCommand { get; set; }

        public SigninModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        public void OnSubmit()
        {
            if (string.IsNullOrEmpty(Email))
            {
                MessagingCenter.Send(this, "SigninAlert", Email);
            }
        }

    }
}

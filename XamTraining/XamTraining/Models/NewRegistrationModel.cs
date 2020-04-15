using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using XamTraining.Views;

namespace XamTraining.Models
{
    class NewRegistrationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Show;
        public NewRegistrationModel()
        {

        }

        public string fullname;
        public string FullName
        {
            get { return fullname; }
            set
            {
                fullname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
            }
        }

        public string email;
        public string EmailId
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmailId"));
            }
        }
        
        public string dob;
        public string DOB
        {
            get { return dob; }
            set
            {
                dob = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DOB"));
            }
        }

        public string department;
        public string Departmnt
        {
            get { return department; }
            set
            {
                department = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Departmnt"));
            }
        }

        public string password;
        private bool isValid;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));

            }

        }
        public string cpassword;
        public string CnfrmPassword
        {
            get { return cpassword; }
            set
            {
                cpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CnfrmPassword"));

            }

        }
        public ICommand SubmitCommand
        {
            get
            {
                return new Command(OnSubmit);
            }
        }
        public ICommand GoToLogin
        {
            get
            {
                return new Command(OnLoginClick);
            }
        }

        public void OnLoginClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public void OnSubmit()
        {
            if (string.IsNullOrEmpty(EmailId) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Departmnt) || string.IsNullOrEmpty(DOB) )
            {
                Show?.Invoke("Please enter all the details", null);
            }
            else if (Password!=CnfrmPassword)
            {
                Show?.Invoke("Passwords not matched", null);
            }
            else
            {
                var inputEmail = "" + EmailId;
                Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
                isValid = regex.IsMatch((inputEmail.ToString()).Trim());
                if (!isValid)
                {
                    Show?.Invoke("Please enter the valid email", null);
                }
                else
                {
                    App.Current.MainPage.Navigation.PushAsync(new HomePage());

                }
            }
        }
    }
}

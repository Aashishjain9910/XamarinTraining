using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "ForgotPasswordActivity")]
    public class ForgotPasswordActivity : Activity
    {
        string emailID, phoneNumber, password;

        EditText emailEditText, phoneEditText;
        Button submitFPButton;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgotPasswordLayout);
            

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            phoneEditText = FindViewById<EditText>(Resource.Id.phoneNumberEditText);
            submitFPButton = FindViewById<Button>(Resource.Id.SubmitFPButton);
             emailID = Intent.GetStringExtra("email");

             phoneNumber = Intent.GetStringExtra("phone");

            password = Intent.GetStringExtra("passWord");

            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            submitFPButton.Click += SubmitFPButton_Click;
        }

        private void SubmitFPButton_Click(object sender, EventArgs e)
        {
            if (isMatched())
            {
                Intent intent = new Intent(this, typeof(ShowPasswordActivity));
                intent.PutExtra("passwordkey", password);

                StartActivity(intent);
            }
        }
        protected override void OnPause()
        {
            base.OnPause();
            submitFPButton.Click-= SubmitFPButton_Click;
        }


        private bool isMatched()
        {
            string checkError = "";
            EditText checkEmail = (EditText)FindViewById(Resource.Id.emailEditText);
            EditText checkPhone = (EditText)FindViewById(Resource.Id.phoneNumberEditText);

            string emailString = checkEmail.Text.ToString();
            string phoneString = checkPhone.Text.ToString();
            emailID = Intent.GetStringExtra("email");

            phoneNumber = Intent.GetStringExtra("phone");


            if (emailString == null || emailString.Equals(""))
            {
                checkError = "Please enter email id";
                checkEmail.Error = checkError;
                _ = checkEmail.RequestFocus();
                return false;
            }

            if (!isValidEmail(emailString))
            {
                checkError = "Please enter valid email";
                checkEmail.Error = checkError;
                _ = checkEmail.RequestFocus();
                return false;
            }


            if (emailString != emailID)
            {
                checkError = "Please enter the registered email";
                checkEmail.Error = checkError;
                _ = checkEmail.RequestFocus();
                return false;
            }

            if (phoneString == null || phoneString.Equals(""))
            {
                checkError = "Please enter phone number";
                checkPhone.Error = checkError;
                _ = checkPhone.RequestFocus();
                return false;
            }

            if (phoneString != phoneNumber)
            {
                checkError = "Please enter the registered phone number associated with this email";
                checkPhone.Error = checkError;
                _ = checkPhone.RequestFocus();
                return false;
            }

            return true;
        }


        private bool isValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.Util.Regex;
using Pattern = Java.Util.Regex.Pattern;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "RegistrationActivity") ]
    public class RegistrationActivity : Activity
    {
        //TextView firstNameTextView;
        //TextView lastNameTextView;
        //TextView emailTextView;
        //TextView departmentTextView;
        //TextView passwordTextView;
        //TextView genderTextView;
        //TextView skillsTextView;

        EditText firstNameEditText,
                 lastNameEditText,
                 emailEditText,
                 phoneNumberEditText,
                 passwordEditText;

        //RadioGroup genderRadioGroup;

        //RadioButton maleRadioButton,
        //            femaleRadioButton;


        Button submitButton, resetButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration_Layout);
            firstNameEditText = FindViewById<EditText>(Resource.Id.firstNameEditText);
            lastNameEditText = FindViewById<EditText>(Resource.Id.lastNameEditText);
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            phoneNumberEditText = FindViewById<EditText>(Resource.Id.phoneNumberEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            //genderRadioGroup = FindViewById<RadioGroup>(Resource.Id.genderRadioGroup);

            submitButton = FindViewById<Button>(Resource.Id.submitButton);
            resetButton = FindViewById<Button>(Resource.Id.resetButton);
            //skillsTextView = FindViewById<TextView>(Resource.Id.skillTextView);
            //skillsTextView.Click += SkillsTextView_Click;

            
        }

        //private void SkillsTextView_Click(object sender, EventArgs e)
        //{
        //    Intent intent = new Intent(this, typeof(LoginActivity));
        //    StartActivity(intent);
        //}

        protected override void OnResume()
        {
            base.OnResume();
            submitButton.Click += SubmitButton_Click;
            resetButton.Click += ResetButton_Click;
        }

        protected override void OnPause()
        {
            base.OnPause();
            submitButton.Click -= SubmitButton_Click;
            resetButton.Click -= ResetButton_Click;
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            Finish();
        }

       public void SubmitButton_Click(object sender, EventArgs e)
        {
           

            if (validInput())
            {
                Intent intent = new Intent(this, typeof(LoginActivity));
                intent.PutExtra("emailValue", emailEditText.Text );
                intent.PutExtra("passwordValue", passwordEditText.Text);
                intent.PutExtra("userFirstNameValue", firstNameEditText.Text);
                intent.PutExtra("phoneNumberValue", phoneNumberEditText.Text);
                
                StartActivity(intent);
            }
        }

        private bool validInput()
        {
            string error_text = "";
            EditText checkFirstName = (EditText)FindViewById(Resource.Id.firstNameEditText);
            EditText checkLastName = (EditText)FindViewById(Resource.Id.lastNameEditText);
            EditText checkEmail = (EditText)FindViewById(Resource.Id.emailEditText);
            EditText checkPhoneNumber = (EditText)FindViewById(Resource.Id.phoneNumberEditText);
            EditText checkPassword = (EditText)FindViewById(Resource.Id.passwordEditText);

            string firstName = checkFirstName.Text.ToString();
            string lastName = checkLastName.Text.ToString();
            string phoneNumber = checkPhoneNumber.Text.ToString();
            string email = checkEmail.Text.ToString();
            string password = checkPassword.Text.ToString();

            if (firstName == null || firstName.Equals(""))
            {
                error_text = "Please enter firstname";
                checkFirstName.Error = error_text;
                _ = checkFirstName.RequestFocus();
                return false;
            }
            
            
            if (lastName == null || lastName.Equals(""))
            {
                error_text = "Please enter lastname";
                checkLastName.Error = error_text;
                _ = checkLastName.RequestFocus();
                return false;
            }
            
            
            if (email == null || email.Equals(""))
            {
                error_text = "Please enter email id";
                checkEmail.Error = error_text;
                _ = checkEmail.RequestFocus();
                return false;
            }

            if (!isValidEmail(email))
            {
                error_text = "Please enter valid email";
                checkEmail.Error = error_text;
                _ = checkEmail.RequestFocus();
                return false;
            }


            if (phoneNumber == null || phoneNumber.Equals(""))
            {
                error_text = "Please enter phone number";
                checkPhoneNumber.Error = error_text;
                _ = checkPhoneNumber.RequestFocus();
                return false;
            }

            if (phoneNumber.Length != 10)
            {
                error_text = "Please enter 10 digit phone number";
                checkPhoneNumber.Error = error_text;
                _ = checkPhoneNumber.RequestFocus();
                return false;
            }


            if (password == null || password.Equals(""))
            {
                error_text = "Please enter password";
                checkPassword.Error = error_text;
                _ = checkPassword.RequestFocus();
                return false;
            }

            if (!IsValidPassword(password))
            {
                error_text = "Please enter password";
                checkPassword.Error = error_text;
                _ = checkPassword.RequestFocus();
                return false;
            }



            return true;
        }
        private bool isValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }

        private bool IsValidPassword(string pass)
        {
            Pattern pattern = Pattern.Compile("[a-zA-Z0-9\\!\\@\\#\\$]{8,24}");
            return !TextUtils.IsEmpty(pass) && pattern.Matcher(pass).Matches();
        }
    }
}
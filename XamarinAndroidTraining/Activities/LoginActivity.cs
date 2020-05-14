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
    [Activity(Label = "LoginActivity", MainLauncher = true) ]
    public class LoginActivity : Activity
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
                 departmentEditText,
                 passwordEditText;

        RadioGroup genderRadioGroup;

        RadioButton maleRadioButton,
                    femaleRadioButton;


        Button submitButton, resetButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginLayout);
            firstNameEditText = FindViewById<EditText>(Resource.Id.firstNameEditText);
            lastNameEditText = FindViewById<EditText>(Resource.Id.lastNameEditText);
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            departmentEditText = FindViewById<EditText>(Resource.Id.departmentEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            genderRadioGroup = FindViewById<RadioGroup>(Resource.Id.genderRadioGroup);

            submitButton = FindViewById<Button>(Resource.Id.submitButton);
            resetButton = FindViewById<Button>(Resource.Id.resetButton);


            
        }

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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (validInput())
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
        }

        private bool validInput()
        {
            string error_text = "";
            EditText checkFirstName = (EditText)FindViewById(Resource.Id.firstNameEditText);
            EditText checkLastName = (EditText)FindViewById(Resource.Id.lastNameEditText);
            EditText checkEmail = (EditText)FindViewById(Resource.Id.emailEditText);
            EditText checkDepartment = (EditText)FindViewById(Resource.Id.departmentEditText);
            EditText checkPassword = (EditText)FindViewById(Resource.Id.passwordEditText);

            string firstName = checkFirstName.Text.ToString();
            string lastName = checkLastName.Text.ToString();
            string department = checkDepartment.Text.ToString();
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


            if (department == null || department.Equals(""))
            {
                error_text = "Please enter department";
                checkDepartment.Error = error_text;
                _ = checkDepartment.RequestFocus();
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
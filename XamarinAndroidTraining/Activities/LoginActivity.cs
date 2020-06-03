﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.Util.Regex;
using Newtonsoft.Json;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using XamarinAndroidTraining.models;
using Pattern = Java.Util.Regex.Pattern;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher=false)]
    public class LoginActivity : Activity, IFacebookCallback
    {
        EditText emailEditText, passwordEditText;
        Button loginButton;
        Button facebookImage;

        string abcd;

        ProfilePictureView mprofile;
        private MyProfileTracker profileTracker;
        private ICallbackManager fBCallManager;

        ImageView googleImage;
        TextView signUpTextView, forgotPassword, TxtName;

        string username, phonenumber, password;
        AlertDialog.Builder dialogBuilder;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);
            SetContentView(Resource.Layout.Login_Layout);

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            string emailString = Intent.GetStringExtra("emailValue");
            emailEditText.Text = emailString;

            username = Intent.GetStringExtra("userFirstNameValue");

            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            password = Intent.GetStringExtra("passwordValue");


            forgotPassword = FindViewById<TextView>(Resource.Id.forgotPasswordTextView);
            TxtName = FindViewById<TextView>(Resource.Id.forgotPasswordTextView);
            phonenumber = Intent.GetStringExtra("phoneNumberValue");



            #region facebookbutton

            facebookImage = FindViewById<Button>(Resource.Id.facebookImage);
            profileTracker = new MyProfileTracker();
            profileTracker.mOnProfileChanged += profileTracker_onProfileChanged;
            profileTracker.StartTracking();

            fBCallManager = CallbackManagerFactory.Create();
            LoginManager.Instance.RegisterCallback(fBCallManager, this);

            facebookImage.Click += (o, e) =>
            {
                if (AccessToken.CurrentAccessToken != null)
                {
                    LoginManager.Instance.LogOut();
                    //facebookImage.Text = "Login";
                }
                else
                {

                    LoginManager.Instance.LogInWithReadPermissions(this, new List<string> { "public_profile", "user_friends" });
                    //loginButton.Text = "Logout";
                }
            };
            
            #endregion



            googleImage = FindViewById<ImageView>(Resource.Id.googleImage);
            signUpTextView = FindViewById<TextView>(Resource.Id.signUpTextView);

            loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            dialogBuilder = new AlertDialog.Builder(this);
           



        }

        protected override void OnResume()
        {
            base.OnResume();
            forgotPassword.Click += ForgotPassword_Click;
            loginButton.Click += LoginButton_Click;

            //facebookImage.Click += FacebookImage_Click;
            googleImage.Click += GoogleImage_Click;
            signUpTextView.Click += SignUpTextView_Click;
        }

        private void ForgotPassword_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ForgotPasswordActivity));
            intent.PutExtra("email", emailEditText.Text);
            intent.PutExtra("phone", phonenumber);
            intent.PutExtra("passWord", password);
            StartActivity(intent);
        }

        private void SignUpTextView_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegistrationActivity));
            StartActivity(intent);
        }

        private void GoogleImage_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GoogleWebViewActivity));
            StartActivity(intent);
        }

        protected override void OnPause()
        {
            base.OnPause();
            forgotPassword.Click -= ForgotPassword_Click;
            loginButton.Click -= LoginButton_Click;
            //facebookImage.Click -= FacebookImage_Click;
            googleImage.Click -= GoogleImage_Click;
            signUpTextView.Click -= SignUpTextView_Click;

        }

        //private void FacebookImage_Click(object sender, EventArgs e)
        //{
        //    Intent intent = new Intent(this, typeof(FacebookWebViewActivity));
        //    StartActivity(intent);
        //}

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (ValidInput())
            {
                Intent intent = new Intent(this, typeof(ProfileActivity));

                //User user = new User()
                //{
                //    Email = emailEditText.Text,
                //    Password = "Jain@9910"
                //};

                //intent.PutExtra("User", JsonConvert.SerializeObject(user));


                //ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
                //ISharedPreferencesEditor edit = pref.Edit();
                //edit.PutString("Email", emailEditText.Text.Trim());
                //edit.PutString("Password", passwordEditText.Text.Trim());
                //edit.Apply();
                this.StartActivity(intent);
                //intent.PutExtra("userFirstname", username);
                //StartActivity(intent);
            }
        }


        private bool ValidInput()
        {
            string error_text = "";
            EditText checkEmail = (EditText)FindViewById(Resource.Id.emailEditText);
            EditText checkPassword = (EditText)FindViewById(Resource.Id.passwordEditText);

            string email = checkEmail.Text.ToString();
            string password = checkPassword.Text.ToString();
            string passwordString = Intent.GetStringExtra("passwordValue");


            if ((email == null || email.Equals("")) && (password == null || password.Equals("")))
            {
                dialogBuilder.SetMessage("Please enter EmailId and Password");
                AlertDialog alertDialog = dialogBuilder.Create();
                alertDialog.SetTitle("Error");
                alertDialog.SetCanceledOnTouchOutside(false);
                alertDialog.SetButton("Ok", (c, ev) =>
                {

                });

                alertDialog.Show();

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


            if (password == null || password.Equals(""))
            {
                error_text = "Please enter password";
                checkPassword.Error = error_text;
                _ = checkPassword.RequestFocus();
                return false;
            }

            if (!IsValidPassword(password))
            {
                error_text = "Please enter correct password";
                checkPassword.Error = error_text;
                _ = checkPassword.RequestFocus();
                return false;
            }

            //if (password != passwordString)
            //{
            //    error_text = "Please enter the Correct Password";
            //    checkPassword.Error = error_text;
            //    _ = checkPassword.RequestFocus();
            //    return false;
            //}

            return true;
        }

        private bool isValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }

        private bool IsValidPassword(string pass)
        {
            Pattern pattern = Pattern.Compile("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\\S+$).{8,}$");
            return !TextUtils.IsEmpty(pass) && pattern.Matcher(pass).Matches();
        }



        public void OnCancel() 
        {
        
        }
        public void OnError(FacebookException p0) 
        {
        
        }
        public void OnSuccess(Java.Lang.Object p0)
        {
            
        }
        void profileTracker_onProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                try
                {
                    abcd = e.mProfile.Name;
                    string dp = e.mProfile.Id;
                    //TxtName.Text = e.mProfile.Name;
                    //mprofile.ProfileId = e.mProfile.Id;
                    //facebookImage.Text = "Logout";
                    Intent intent = new Intent(this, typeof(ProfileActivity));
                    //intent.PutExtra("pId", mprofile.ProfileId);
                    intent.PutExtra("name", abcd);
                    intent.PutExtra("dpId", dp);
                    

                    StartActivity(intent);
                }
                catch (Java.Lang.Exception ex) { }
            }
            //else
            //{
                
            //    //TxtName.Text = "Name";
            //    //mprofile.ProfileId = null;
            //    //facebookImage.Text = "Logout";
            //}

           
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            fBCallManager.OnActivityResult(requestCode, (int)resultCode, data);
        }

        protected override void OnDestroy()
        {
            profileTracker.StopTracking();
            base.OnDestroy();
        }

        public class MyProfileTracker : ProfileTracker
        {
            public event EventHandler<OnProfileChangedEventArgs> mOnProfileChanged;
            protected override void OnCurrentProfileChanged(Profile oldProfile, Profile newProfile)
            {
                if (mOnProfileChanged != null)
                {
                    mOnProfileChanged.Invoke(this, new OnProfileChangedEventArgs(newProfile));
                }
            }
        }
        public class OnProfileChangedEventArgs : EventArgs
        {
            public Profile mProfile;
            public OnProfileChangedEventArgs(Profile profile)
            {
                mProfile = profile;
            }

        }
    }
}
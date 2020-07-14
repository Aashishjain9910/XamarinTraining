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
using Android.Gms.Common.Apis;
using Android.Gms.Tasks;
using Android.Support.V7.App;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Auth.Api;
using Firebase.Auth;
using Firebase;
using Pattern = Java.Util.Regex.Pattern;
using AlertDialog = Android.App.AlertDialog;
using Xamarin.Auth;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "LoginActivity", MainLauncher = false)]
    public class LoginActivity : Activity, IFacebookCallback, IOnSuccessListener, IOnFailureListener
    {
        EditText emailEditText, passwordEditText;
        Button loginButton;
        Button facebookImage;
        Button twitterButton;

        string abcd;
        private MyProfileTracker profileTracker;
        private ICallbackManager fBCallManager;


        Button googleButton;
        GoogleSignInOptions gso;
        GoogleApiClient googleApiClient;

        FirebaseAuth firebaseAuth;



        TextView signUpTextView, forgotPassword, TxtName;

        string username, phonenumber, password;
        AlertDialog.Builder dialogBuilder;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);
            SetContentView(Resource.Layout.Login_Layout);

            #region normal login
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            string emailString = Intent.GetStringExtra("emailValue");
            emailEditText.Text = emailString;
            username = Intent.GetStringExtra("userFirstNameValue");
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            password = Intent.GetStringExtra("passwordValue");
            forgotPassword = FindViewById<TextView>(Resource.Id.forgotPasswordTextView);
            TxtName = FindViewById<TextView>(Resource.Id.forgotPasswordTextView);
            phonenumber = Intent.GetStringExtra("phoneNumberValue");

            loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            dialogBuilder = new AlertDialog.Builder(this);
            #endregion


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


            #region googlebutton
            googleButton = FindViewById<Button>(Resource.Id.googleImage);
            gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestIdToken("1037739809912-lujoj1fsmh5kdbk4qocbcqcge5csprm6.apps.googleusercontent.com")
                .RequestEmail()
                .Build();

            googleApiClient = new GoogleApiClient.Builder(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso).Build();
            googleApiClient.Connect();

            firebaseAuth = GetFirebaseAuth();
            signUpTextView = FindViewById<TextView>(Resource.Id.signUpTextView);
            #endregion


            #region twitterbutton
            twitterButton = FindViewById<Button>(Resource.Id.twitterImage);
            twitterButton.Click += delegate { LoginTwitter(); };

            #endregion

        }


        #region normal login
        protected override void OnResume()
        {
            base.OnResume();
            forgotPassword.Click += ForgotPassword_Click;
            loginButton.Click += LoginButton_Click;

            //facebookImage.Click += FacebookImage_Click;
            googleButton.Click += googleButton_Click;
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

        
        protected override void OnPause()
        {

            base.OnPause();
            forgotPassword.Click -= ForgotPassword_Click;
            loginButton.Click -= LoginButton_Click;
            //facebookImage.Click -= FacebookImage_Click;
            signUpTextView.Click -= SignUpTextView_Click;
            googleButton.Click -= googleButton_Click;
        }



        

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

        #endregion


        #region facebook login
        public void OnCancel()
        {

        }
        public void OnError(FacebookException p0)
        {

        }
        public void OnSuccess(Java.Lang.Object p0)
        {
            if (code == 1)
            {

                nameText = firebaseAuth.CurrentUser.DisplayName;
                email = firebaseAuth.CurrentUser.Email;
                Toast.MakeText(this, "Login successful", ToastLength.Short).Show();

                Intent intent = new Intent(this, typeof(ProfileActivity));
                intent.PutExtra("name", nameText);
                intent.PutExtra("emailId", email);
                StartActivity(intent);
            }
        }
        void profileTracker_onProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                try
                {
                    abcd = e.mProfile.Name;
                    string dp = e.mProfile.Id;
                    Intent intent = new Intent(this, typeof(ProfileActivity));
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
        int code;
        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {

            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 64206)
            {
                code = requestCode;
                fBCallManager.OnActivityResult(requestCode, (int)resultCode, data);
            }
            else if (requestCode == 1)
            {
                code = requestCode;
                GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                if (result.IsSuccess)
                {
                    GoogleSignInAccount account = result.SignInAccount;
                    LoginWithFirebase(account);
                }
            }
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


        #endregion


        #region google login
        private FirebaseAuth GetFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(this);
            FirebaseAuth mAuth;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetProjectId("xamarinandroidtraining-279113")
                    .SetApplicationId("xamarinandroidtraining-279113")
                    .SetApiKey("AIzaSyALH9EDGO6p0psNvu4cDz826IkYIeW33j4")
                    .SetDatabaseUrl("https://xamarinandroidtraining-279113.firebaseio.com")
                    .SetStorageBucket("xamarinandroidtraining-279113.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(this, options);
                mAuth = FirebaseAuth.Instance;
            }
            else
            {
                mAuth = FirebaseAuth.Instance;
            }
            return mAuth;
        }

        private void googleButton_Click(object sender, System.EventArgs e)
        {

            if (firebaseAuth.CurrentUser == null)
            {
                var intents = Auth.GoogleSignInApi.GetSignInIntent(googleApiClient);
                StartActivityForResult(intents, 1);

            }
            else
            {
                firebaseAuth.SignOut();

            }

        }

        //protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        //{
        //    base.OnActivityResult(requestCode, resultCode, data);

        //    if (requestCode == 1)
        //    {
        //        GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
        //        if (result.IsSuccess)
        //        {
        //            GoogleSignInAccount account = result.SignInAccount;
        //            LoginWithFirebase(account);
        //        }
        //    }
        //}

        private void LoginWithFirebase(GoogleSignInAccount account)
        {
            var credentials = GoogleAuthProvider.GetCredential(account.IdToken, null);
            firebaseAuth.SignInWithCredential(credentials).AddOnSuccessListener(this)
                .AddOnFailureListener(this);
        }




        void IOnFailureListener.OnFailure(Java.Lang.Exception e)
        {
            Toast.MakeText(this, "Login Failed", ToastLength.Short).Show();

        }


        string email, nameText;

        //void IOnSuccessListener.OnSuccess(Java.Lang.Object result)
        //{

        //    //displayNameText.Text = firebaseAuth.CurrentUser.DisplayName;
        //    //emailText.Text = firebaseAuth.CurrentUser.Email;
        //    //nameText = displayNameText.Text;
        //    //email = emailText.Text;
        //    //Toast.MakeText(this, "Login successful", ToastLength.Short).Show();

        //    //Intent intent = new Intent(this, typeof(ProfileActivity));
        //    //intent.PutExtra("name", nameText);
        //    //intent.PutExtra("emailId", email);
        //    //StartActivity(intent);
        //}


        #endregion


        #region twitter login

        private void LoginTwitter()
        {
            OAuth1Authenticator auth = new OAuth1Authenticator(
                consumerKey: "rTkBXip6Mx0ViCgx42BzJUQNR",
                consumerSecret: "ea0N8wzdVr5F3u59y0bL9h0d4wGF81EFSjHaOx9oQGQrYmKymx",
                requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
                authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
                accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
               callbackUrl: new Uri("https://xamarinandroidtraining-279113.firebaseapp.com/__/auth/handler")


            );

            auth.Completed += twitter_auth_Completed;
            StartActivity(auth.GetUI(this));
        }

        private void twitter_auth_Completed(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            if (eventArgs.IsAuthenticated)
            {
                Toast.MakeText(this, "LoggedIn with Twitter", ToastLength.Long).Show();

            }
        }


        #endregion

    }
}

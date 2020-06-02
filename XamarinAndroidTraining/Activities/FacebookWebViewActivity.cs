using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Webkit;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "FacebookWebViewActivity")]
    public class FacebookWebViewActivity : Activity, IFacebookCallback
    {
        TextView  TxtName;
        //LoginButton BtnFBLogin;
        ProfilePictureView mprofile;
        private MyProfileTracker profileTracker;
        private ICallbackManager fBCallManager;

        Button loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);



            SetContentView(Resource.Layout.Facebook_WebView);

            loginButton = FindViewById<Button>(Resource.Id.loginButton);

            
            profileTracker = new MyProfileTracker();
            profileTracker.mOnProfileChanged += profileTracker_onProfileChanged;
            profileTracker.StartTracking();

            
            
            TxtName = FindViewById<TextView>(Resource.Id.TxtName);
            mprofile = FindViewById<ProfilePictureView>(Resource.Id.ImgPro);



            //BtnFBLogin = FindViewById<LoginButton>(Resource.Id.fblogin);
            //BtnFBLogin.SetReadPermissions(new List<string> { "user_friends", "public_profile" });
            //BtnFBLogin.RegisterCallback(fBCallManager, this);


            fBCallManager = CallbackManagerFactory.Create();
            LoginManager.Instance.RegisterCallback(fBCallManager, this);

            loginButton.Click += (o, e) =>
            {
                if (AccessToken.CurrentAccessToken != null)
                {
                    LoginManager.Instance.LogOut();
                    loginButton.Text = "Login";
                }
                else
                {

                    LoginManager.Instance.LogInWithReadPermissions(this, new List<string> { "public_profile", "user_friends" });
                    //loginButton.Text = "Logout";
                }
            };



        }

        protected override void OnResume()
        {
            base.OnResume();
            //loginButton.Click += LoginButton_Click;
        }

        //private void LoginButton_Click(object sender, EventArgs e)
        //{
        //    Intent intent = new Intent(this, typeof(LoginActivity));
        //    StartActivity(intent);
        //}

        protected override void OnPause()
        {
            base.OnPause();
            //loginButton.Click -= LoginButton_Click;

        }

        public void OnCancel() { }
        public void OnError(FacebookException p0) { }
        public void OnSuccess(Java.Lang.Object p0)
        {
            Intent intent = new Intent(this, typeof(ProfileActivity));
            intent.PutExtra("pId", mprofile.ProfileId);
            intent.PutExtra("name", TxtName.Text);
            StartActivity(intent);
        }
        void profileTracker_onProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                try
                {
                    
                    TxtName.Text = e.mProfile.Name;
                    mprofile.ProfileId = e.mProfile.Id;
                    loginButton.Text = "Logout";
                }
                catch (Java.Lang.Exception ex) { }
            }
            else
            {
                TxtName.Text = "Name";
                mprofile.ProfileId = null;
                loginButton.Text = "Logout";
            }
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




        //public class HybridWebViewClient : WebViewClient
        //{
        //    public override bool ShouldOverrideUrlLoading(WebView view, string url)
        //    {

        //        view.LoadUrl(url);
        //        return true;
        //    }
        //    public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
        //    {
        //        base.OnPageStarted(view, url, favicon);
        //    }
        //    public override void OnPageFinished(WebView view, string url)
        //    {
        //        base.OnPageFinished(view, url);
        //    }
        //    public override void OnReceivedError(WebView view, [GeneratedEnum] ClientError errorCode, string description, string failingUrl)
        //    {
        //        base.OnReceivedError(view, errorCode, description, failingUrl);
        //    }
        //}

    }
}
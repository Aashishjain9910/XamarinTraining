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

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "FacebookWebViewActivity",MainLauncher =true)]
    public class FacebookWebViewActivity : Activity, IFacebookCallback
    {
        TextView  TxtName;
        LoginButton BtnFBLogin;
        ProfilePictureView mprofile;
        private MyProfileTracker profileTracker;
        private ICallbackManager fBCallManager;

        Button loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            FacebookSdk.SdkInitialize(this.ApplicationContext);
            profileTracker = new MyProfileTracker();
            profileTracker.mOnProfileChanged += profileTracker_onProfileChanged;
            profileTracker.StartTracking();
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Facebook_WebView);
            BtnFBLogin = FindViewById<LoginButton>(Resource.Id.fblogin);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            TxtName = FindViewById<TextView>(Resource.Id.TxtName);
            mprofile = FindViewById<ProfilePictureView>(Resource.Id.ImgPro);
            BtnFBLogin.SetReadPermissions(new List<string> { "user_friends", "public_profile" });
            fBCallManager = CallbackManagerFactory.Create();
            BtnFBLogin.RegisterCallback(fBCallManager, this);


        }

        protected override void OnResume()
        {
            base.OnResume();
            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }

        protected override void OnPause()
        {
            base.OnPause();
            loginButton.Click -= LoginButton_Click;

        }

        public void OnCancel() { }
        public void OnError(FacebookException p0) { }
        public void OnSuccess(Java.Lang.Object p0) { }
        void profileTracker_onProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                try
                {
                    
                    TxtName.Text = e.mProfile.Name;
                    mprofile.ProfileId = e.mProfile.Id;
                }
                catch (Java.Lang.Exception ex) { }
            }
            else
            {
                TxtName.Text = "Name";
                mprofile.ProfileId = null;
            }
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            fBCallManager.OnActivityResult(requestCode, (int)resultCode, data);
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
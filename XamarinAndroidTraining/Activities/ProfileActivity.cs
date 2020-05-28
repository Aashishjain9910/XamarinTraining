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
using Xamarin.Facebook;
using Xamarin.Facebook.Login.Widget;
using static XamarinAndroidTraining.Activities.FacebookWebViewActivity;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity,IFacebookCallback
    {

        private MyProfileTracker profileTracker;
        private ICallbackManager fBCallManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);
            profileTracker = new MyProfileTracker();
            profileTracker.StartTracking();
            SetContentView(Resource.Layout.ProfileLayout);



        }


        public void OnCancel() { }
        public void OnError(FacebookException p0) { }
        public void OnSuccess(Java.Lang.Object p0) { }


    }

}
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
    [Activity(Label = "UserLoginActivity", MainLauncher =true)]
    public class UserLoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserLoginPage);
            // Create your application here
        }
    }
}
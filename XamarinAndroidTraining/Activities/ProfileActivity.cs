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
    public class ProfileActivity : Activity
    {
        string usrName, usrPic;
        TextView TxtName;
        //LoginButton BtnFBLogin;
        ProfilePictureView mprofile;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);
           
            SetContentView(Resource.Layout.ProfileLayout);


            TxtName = FindViewById<TextView>(Resource.Id.TxtName);
            mprofile = FindViewById<ProfilePictureView>(Resource.Id.ImgPro);



           usrName  = Intent.GetStringExtra("name");
            usrPic = Intent.GetStringExtra("dpId");
            TxtName.Text = usrName;
            mprofile.ProfileId = usrPic;
        }



    }

}
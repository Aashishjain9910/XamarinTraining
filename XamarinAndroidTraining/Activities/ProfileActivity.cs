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
        string usrName, usrPic, usrEmail;
        TextView TxtName, emailText;
        //LoginButton BtnFBLogin;
        ProfilePictureView mprofile;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            FacebookSdk.SdkInitialize(this.ApplicationContext);
           
            SetContentView(Resource.Layout.ProfileLayout);


            mprofile = FindViewById<ProfilePictureView>(Resource.Id.ImgPro);
            TxtName = FindViewById<TextView>(Resource.Id.TxtName);
            emailText = FindViewById<TextView>(Resource.Id.emailText);


           usrName  = Intent.GetStringExtra("name");
            usrPic = Intent.GetStringExtra("dpId");
            usrEmail = Intent.GetStringExtra("emailId");
            TxtName.Text = usrName;
            mprofile.ProfileId = usrPic;
            emailText.Text = usrEmail;
        }



    }

}
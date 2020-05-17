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
    [Activity(Label = "ShowPasswordActivity")]
    public class ShowPasswordActivity : Activity
    {
        TextView passEditText;
        Button OKButton;
        string password;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShowPasswordLayout);
            passEditText = FindViewById<TextView>(Resource.Id.passEditText);

            password = Intent.GetStringExtra("passwordkey");
            passEditText.Text =  $"Welcome, Your password is: {password}";

            OKButton = FindViewById<Button>(Resource.Id.OKButton);

        }

        protected override void OnResume()
        {
            base.OnResume();
            OKButton.Click += OKButton_Click;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Intent intent= new Intent(this, typeof(LoginActivity));
            intent.PutExtra("passwordValue",password);


            StartActivity(intent);
        }

        protected override void OnPause()
        {
            base.OnPause();
            OKButton.Click -= OKButton_Click;
        }


    }
}
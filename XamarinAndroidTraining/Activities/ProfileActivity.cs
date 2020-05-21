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
    [Activity(Label = "ProfileActivity")]
    public class ProfileActivity : Activity
    {
        Button nextButton;
        TextView helloTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProfileLayout);
            nextButton = FindViewById<Button>(Resource.Id.nextButton);
            helloTextView = FindViewById<TextView>(Resource.Id.helloTextView);
            // Create your application here
        }



        protected override void OnResume()
        {
            base.OnResume();
            nextButton.Click += NextButton_Click;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Intent intent1 = new Intent();
            intent1.SetData(Android.Net.Uri.Parse(helloTextView.Text));
            SetResult(Result.Ok, intent1);
            this.Finish();
        }


        protected override void OnPause()
        {
            base.OnPause();
            nextButton.Click += NextButton_Click;

        }
    }
}
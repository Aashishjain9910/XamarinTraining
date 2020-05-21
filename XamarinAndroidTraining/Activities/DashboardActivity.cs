using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "DashboardActivity")]
    public class DashboardActivity : Activity
    {
        static int requestId = 1;
        Button nextButton;
        TextView msgText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DashboardLayout);
            msgText = FindViewById<TextView>(Resource.Id.msgText);
            nextButton = FindViewById<Button>(Resource.Id.nextButton);
            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            nextButton.Click += NextButton_Click;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            StartActivityForResult(typeof(ProfileActivity), requestId);


            //Intent intent = new Intent(this, typeof(ProfileActivity));
            ////StartActivityForResult(intent, requestId);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == requestId)
            {
                if (resultCode == Result.Ok)
                {
                    msgText.Text = data.Data.ToString();
                }
            }
        }


        protected override void OnPause()
        {
            base.OnPause();
            nextButton.Click -= NextButton_Click;

        }
    }
}
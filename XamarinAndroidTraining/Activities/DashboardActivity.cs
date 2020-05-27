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
    [Activity(Label = "DashboardActivity", Theme = "@style/Theme.DesignDemo", MainLauncher=true)]
    public class DashboardActivity : Activity
    {
        //static int requestId = 1;
        //Button nextButton;
        //TextView msgText;
        Button camera, gallery, contacts, listView, login;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DashboardLayout);
            //msgText = FindViewById<TextView>(Resource.Id.msgText);
            //nextButton = FindViewById<Button>(Resource.Id.nextButton);
            // Create your application here
            camera = FindViewById<Button>(Resource.Id.camera);
            gallery = FindViewById<Button>(Resource.Id.gallery);
            contacts = FindViewById<Button>(Resource.Id.contacts);
            listView = FindViewById<Button>(Resource.Id.listView);
            login = FindViewById<Button>(Resource.Id.login);


        }


        protected override void OnResume()
        {
            base.OnResume();
            camera.Click += Camera_Click;

            gallery.Click += Gallery_Click;
            contacts.Click += Contacts_Click;
            listView.Click += ListView_Click;
            login.Click += Login_Click;
            //nextButton.Click += NextButton_Click;
        }

        private void Camera_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CameraActivity));
            StartActivity(intent);
        }

        private void Gallery_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GalleryActivity));
            StartActivity(intent);
        }

        private void Contacts_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ContactListActivity));
            StartActivity(intent);
        }

        private void ListView_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ListViewAdapterActivity));
            StartActivity(intent);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }




        //private void NextButton_Click(object sender, EventArgs e)
        //{
        //    StartActivityForResult(typeof(ProfileActivity), requestId);


        //    //Intent intent = new Intent(this, typeof(ProfileActivity));
        //    ////StartActivityForResult(intent, requestId);
        //}

        //protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        //{
        //    base.OnActivityResult(requestCode, resultCode, data);
        //    if (requestCode == requestId)
        //    {
        //        if (resultCode == Result.Ok)
        //        {
        //            msgText.Text = data.Data.ToString();
        //        }
        //    }
        //}


        protected override void OnPause()
        {
            base.OnPause();

            camera.Click -= Camera_Click;

            gallery.Click -= Gallery_Click;
            contacts.Click -= Contacts_Click;
            listView.Click -= ListView_Click;
            login.Click -= Login_Click;


            //nextButton.Click -= NextButton_Click;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;


namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "DashboardActivity", Theme = "@style/Theme.DesignDemo",LaunchMode =LaunchMode.SingleTask)]
    public class DashboardActivity : AppCompatActivity
    {
        //static int requestId = 1;
        //Button nextButton;
        //TextView msgText;
        Button camera, gallery, contacts, listView, login;
        static readonly string TAG = "MainActivity";
        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

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

            CreateNotificationChannel();
        }


        #region notification
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channel = new NotificationChannel(CHANNEL_ID,
                                                  "FCM Notifications",
                                                  NotificationImportance.Default)
            {

                Description = "Firebase Cloud Messages appear in this channel"
            };

            var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
        #endregion


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

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            Toast.MakeText(Android.App.Application.Context, "this is fcm notificatin dashboard page", ToastLength.Long).Show();
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
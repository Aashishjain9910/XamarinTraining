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
    [Activity(Label = "BroadcastMessageActivity", MainLauncher =true)]
    public class BroadcastMessageActivity : Activity
    {
        MyBroadcastReceiver myreceiver;
        IntentFilter intentfilter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BroadcastMessageLayout);
            Button btnsendmessage = FindViewById<Button>(Resource.Id.sendBroadcast);

            myreceiver = new MyBroadcastReceiver();
            intentfilter = new IntentFilter("MY_SPECIFIC_ACTION");
            btnsendmessage.Click += (sender, e) =>
            {
                Intent i = new Intent("MY_SPECIFIC_ACTION");
                i.PutExtra("key", "some value from intent");
                SendOrderedBroadcast(i, null);
                //   SendOrderedBroadcast(i, null);

            };
        }


        protected override void OnResume()
        {
            base.OnResume();
            intentfilter.Priority=20;
            RegisterReceiver(myreceiver, intentfilter);
        }
        [Android.Runtime.Register("OnPause()", "()V", "GetOnPauseHandler")]
        protected override void OnPause()
        {
            base.OnPause();
            UnregisterReceiver(myreceiver);
        }
    }

    [BroadcastReceiver(Enabled = true)]
    public class MyBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent i)
        {
            Toast.MakeText(context, "Received broadcast in MyBroadcastReceiver, " +
                            " value received: " + i.GetStringExtra("key"),
                            ToastLength.Long).Show();
        }
    }

}
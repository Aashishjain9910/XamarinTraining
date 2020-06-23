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

namespace XamarinAndroidTraining.models
{
    [BroadcastReceiver(Enabled = true)]
    public class MySecondBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent i)
        {
            Toast.MakeText(context, "Received broadcast in MySecondBroadcastReceiver; " +
                            " value received: " + i.GetStringExtra("key"), ToastLength.Long).Show();

        }
    }
}
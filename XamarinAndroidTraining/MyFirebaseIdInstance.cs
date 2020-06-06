using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Iid;

namespace XamarinAndroidTraining
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT"})]
   public class MyFirebaseIdInstance:FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            SendTokenToServer(refreshedToken);
        }

        private void SendTokenToServer(string refreshedToken)
        {
            Log.Debug(PackageName, refreshedToken);
        }
    }
}



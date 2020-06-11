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
using Android.Gms.Common;
using Firebase.Messaging;
using Android.Support.V4.App;

namespace XamarinAndroidTraining.Activities
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    
    public class MyMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug("/////////////////", "////////////////////////");
            foreach (var li in message.Data.Values)
            {
                Log.Debug("/////////////////", li);

            }
            //   Log.Debug("****",message.Data.Values.ToString());  
            Log.Debug("/////////////////", "////////////////////////");
            Log.Debug(TAG, "From: " + message.From);
            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
            var body = message.GetNotification().Body;
            SendNotification(body, message.Data);
        }
        void SendNotification(string messageBody, IDictionary<string, string> data)
        {
            var intent = new Intent(Application.Context, typeof(DashboardActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            foreach (var key in data.Keys)
            {
                intent.PutExtra(key, data[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(Application.Context,
                                                          DashboardActivity.NOTIFICATION_ID,
                                                          intent,
                                                          PendingIntentFlags.UpdateCurrent);

            var notificationBuilder = new NotificationCompat.Builder(Application.Context, DashboardActivity.CHANNEL_ID)
                                      .SetSmallIcon(Resource.Drawable.User)
                                      .SetContentTitle("FCM Message")
                                      .SetContentText(messageBody)
                                      .SetAutoCancel(true)
                                      .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManagerCompat.From(Application.Context);
            notificationManager.Notify(DashboardActivity.NOTIFICATION_ID, notificationBuilder.Build());
        }
    }
}
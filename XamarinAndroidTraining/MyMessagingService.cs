﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;

namespace XamarinAndroidTraining
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.Messaging_EVENT" })]
    public class MyMessagingService:FirebaseMessagingService
    {
        private readonly string NOTIFICATION_CHANNEL_ID= "com.companyname.xamarinandroidtraining";

        public override void OnMessageReceived(RemoteMessage message)
        {
            if (!message.Data.GetEnumerator().MoveNext())
                SendNotification(message.GetNotification().Title, message.GetNotification().Body);

            else
                SendNotification(message.Data);
        }

        private void SendNotification(IDictionary<string, string> data)
        {
            string title, body;
            data.TryGetValue("title", out title);
            data.TryGetValue("body", out body);

            SendNotification(title, body);
        
        
        }

        private void SendNotification(string title, string body)
        {
            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, "Notification Channel", Android.App.NotificationImportance.Default);

                notificationChannel.Description = "XAmarin.Android Training ";
                notificationChannel.SetVibrationPattern(new long[] { 0, 1000, 500, 1000 });

                notificationManager.CreateNotificationChannel(notificationChannel);

            }

            NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID);

            notificationBuilder.SetAutoCancel(true)
                .SetDefaults(-1)
                .SetWhen(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
                .SetContentTitle(title)
                .SetContentText(body)
                .SetContentInfo("info");

            notificationManager.Notify(new Random().Next(), notificationBuilder.Build());

        }
    }
}
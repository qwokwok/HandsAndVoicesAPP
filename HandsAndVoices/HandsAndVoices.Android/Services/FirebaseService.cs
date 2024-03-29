﻿using Android.App;
using Android.Content;
using Android.OS;
using Firebase.Messaging;
using HandsAndVoices.Services;

namespace HandsAndVoices.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            SendLocalNotification();
        }

        void SendLocalNotification()
        {
            var message = BackgroundService.GetCurrentTopic();

            // notification will be stopped receiving when the app has been on a specific device for more than 90 days
            if(App.DayCount < 91)
            {
                var importance = NotificationImportance.Low;
                NotificationChannel chan = new NotificationChannel("com.companyname.handsandvoices", "HV", importance);
                chan.EnableVibration(true);

                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                intent.PutExtra("message", "");
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

                var notificationBuilder = new Notification.Builder(this, "com.companyname.handsandvoices")
                    .SetContentTitle("Hands and Voices")
                    .SetSmallIcon(Resource.Drawable.small)
                    .SetContentText(message)
                    .SetAutoCancel(true)
                    .SetContentIntent(pendingIntent);

                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    notificationBuilder.SetChannelId("com.companyname.handsandvoices");
                }

                var notificationManager = NotificationManager.FromContext(this);
                notificationManager.CreateNotificationChannel(chan);
                notificationManager.Notify(0, notificationBuilder.Build());
            }
        }
    }
}
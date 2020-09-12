//using Android.App;
//using Android.Content;
//using Android.Graphics;
//using Android.OS;
//using Android.Support.V4.App;
//using HandsAndVoices.Services;

//namespace HandsAndVoices.Droid.Services
//{
//    [BroadcastReceiver]
//    public class AlarmReceiver : BroadcastReceiver
//    {
//        public const string CHANNEL = "com.companyname.handsandvoices";
//        public const int NOTIFY_ID = 1100;

//        public override void OnReceive(Android.Content.Context context, Intent intent)
//        {
//            //var message = BackgroundService.Check();
//            //var message = FirebaseService.SendLocalNotification();
//            var title = "Hands and Voices";

//            var importance = NotificationImportance.High;
//            NotificationChannel chan = new NotificationChannel(CHANNEL, "HV", importance);
//            chan.EnableVibration(true);
//            chan.LockscreenVisibility = NotificationVisibility.Public;

//            var resultIntent = new Intent(context, typeof(MainActivity));
//            intent.AddFlags(ActivityFlags.ClearTop);
//            var pendingIntent = PendingIntent.GetActivity(context, 0, resultIntent, PendingIntentFlags.UpdateCurrent);

//            var notificationBuilder = new NotificationCompat.Builder(context, CHANNEL)
//                .SetSmallIcon(Resource.Drawable.small)
//                .SetContentTitle(title)
//                .SetLargeIcon(BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.icon))
//                //.SetContentText(message)
//                .SetContentIntent(pendingIntent)
//                .SetAutoCancel(true)
//                .SetChannelId(CHANNEL);

//            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Android.Content.Context.NotificationService);
//            notificationManager.CreateNotificationChannel(chan);

//            notificationManager.Notify(NOTIFY_ID, notificationBuilder.Build());
//        }
//    }
//}
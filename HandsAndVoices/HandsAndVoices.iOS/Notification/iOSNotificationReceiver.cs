﻿//using HandsAndVoices.Services;
//using System;
//using UserNotifications;
//using Xamarin.Forms;

//namespace HandsAndVoices.iOS.Notification
//{
//    public class iOSNotificationReceiver : UNUserNotificationCenterDelegate
//    {
//        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
//        {
//            DependencyService.Get<INotificationManager>().ReceiveNotification(notification.Request.Content.Title, notification.Request.Content.Body);

//            // alerts are always shown for demonstration but this can be set to "None"
//            // to avoid showing alerts if the app is in the foreground
//            completionHandler(UNNotificationPresentationOptions.Alert);
//        }
//    }
//}
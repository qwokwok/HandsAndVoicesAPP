﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HandsAndVoices.Services
{
    public class BackgroundService
    {
        public static INotificationManager notificationManager = DependencyService.Get<INotificationManager>();

        public static void Check(object sender, System.Timers.ElapsedEventArgs e)
        {
            App.FirstTime = Preferences.Get("date_key", DateTime.Parse("1/1/2000"));
            App.DayCount = Convert.ToInt32((DateTime.Now - App.FirstTime).TotalDays) + 1;

            if(App.DayCount >= App.Advices.Count)
            {
                App.Advices.Clear();
                App.Advices = ReadJson.GetList();
                var lastIndex = App.Advices.Count - 1;
                notificationManager.ScheduleNotification(
                    "Hands and Voices", "New article - " + App.Advices[lastIndex].TitleTopic);
            }
        }
    }
}

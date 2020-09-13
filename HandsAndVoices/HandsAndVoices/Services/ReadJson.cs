using HandsAndVoices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Essentials;

namespace HandsAndVoices.Services
{
    public class ReadJson
    {
        public static List<Advice> Advices { get; set; } = GetList();
        public static List<Advice> GetList()
        {
            var list = new List<Advice>();

            var assembly = typeof(App).GetTypeInfo().Assembly;

            using Stream stream = assembly.GetManifestResourceStream("HandsAndVoices.Data.90DatasInfo.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Advice>>(json);

                // if a value is null, it will return true
                var isFirstTime = Preferences.Get("isFirst_key", true);
                if (isFirstTime)
                {
                    // stores date of first time using the app
                    Preferences.Set("isFirst_key", false);
                    var date = DateTime.Today;
                    var morning = new TimeSpan(6, 0, 0);
                    date = date.Date + morning;

                    Preferences.Set("date_key", date);
                    App.FirstTime = date;
                }
                else
                {
                    App.FirstTime = Preferences.Get("date_key", DateTime.Parse("1/1/2000"));
                }

                // --- ---

                // converts to universal time
                var now = DateTime.Now.ToUniversalTime();

                // decreases by 4 hours to get time at eastern standard zone
                var current = now - new TimeSpan(4, 0, 0);

                App.DayCount = (int)(Math.Floor((current - App.FirstTime).TotalDays) + 1);
                App.DayCount = 90; // If you want to test with any number of days have been past, enter 1-90 or comment out this line if you wish to test with actual day.
                // --- ---

                list = list.Where(x => x.Day <= App.DayCount).ToList();
                list = AddComingSoonItem(list);
            }
            return list;
        }

        static List<Advice> AddComingSoonItem(List<Advice> advices)
        {
            if (advices.Count == 90)
            {
                advices.Add(new Advice()
                {
                    Day = 0,
                    TitleTopic = "The End!",
                    ArticleImage = "coming.png",
                    DhhName = "Coming soon!",
                    ParentName = "Coming soon!",
                    ResourcesToExplore = "Coming soon!",
                    ResourceImage = "coming.png",
                    DhhPhoto = "coming.png",
                    ParentPhoto = "coming.png"
                });
            }
            else
            {
                advices.Add(new Advice()
                {
                    Day = 0,
                    TitleTopic = "Coming soon!",
                    ArticleImage = "coming.png",
                    DhhName = "Coming soon!",
                    ParentName = "Coming soon!",
                    ResourcesToExplore = "Coming soon!",
                    ResourceImage = "coming.png",
                    DhhPhoto = "coming.png",
                    ParentPhoto = "coming.png"
                });
            }

            return advices;
        }
    }
}

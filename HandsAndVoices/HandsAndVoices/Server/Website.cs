using HandsAndVoices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Xamarin.Essentials;

namespace HandsAndVoices.Server
{
    public class Website
    {
        public static List<Advice> Advices { get; set; } = GetList();

        static List<Advice> GetList()
        {
            var client = new WebClient();
            var list = new List<Advice>();
            Stream all = client.OpenRead("https://people.rit.edu/qpn6238/wuw/90DatasInfo.json");
            using (StreamReader reader = new StreamReader(all))
            {
                var page = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Advice>>(page);

                // if a value is null, it will return true
                var isFirstTime = Preferences.Get("isFirst_key", true);
                if (isFirstTime)
                {
                    // stores date of first time using the app
                    Preferences.Set("isFirst_key", false);
                    var date = DateTime.Today;
                    Preferences.Set("date_key", date);
                    App.FirstTime = date;
                }
                else
                {
                    App.FirstTime = Preferences.Get("date_key", DateTime.Parse("1/1/2000"));
                }

                // --- ---
                App.DayCount = Convert.ToInt32((DateTime.Now - App.FirstTime).TotalDays) + 1;
                App.DayCount = 30; // If you want to test with any number of days have been past, enter 1-90 or comment out this line if you wish to test with actual day.
                // --- ---

                list = list.Where(x => x.Day <= App.DayCount).ToList();
                list = AddComingSoonItem(list);
            }
            return list;
        }

        static List<Advice> AddComingSoonItem(List<Advice> advices)
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

            return advices;
        }
    }
}

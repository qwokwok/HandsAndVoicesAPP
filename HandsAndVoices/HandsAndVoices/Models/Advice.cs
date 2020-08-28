﻿using System;
using FFImageLoading.Cache;
using FFImageLoading.Forms;
using Newtonsoft.Json;

namespace HandsAndVoices.Models
{
    public class Advice
    {
        #region Json Properties
        [JsonProperty("Day")]
        public long Day { get; set; }

        [JsonProperty("Title/Topic")]
        public string TitleTopic { get; set; }

        [JsonProperty("Content Article/Video")]
        public string ContentArticleVideo { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }

        [JsonProperty("Parent Quote")]
        public string ParentQuote { get; set; }

        [JsonProperty("Parent Name")]
        public string ParentName { get; set; }

        [JsonProperty("Resources to Explore")]
        public string ResourcesToExplore { get; set; }

        [JsonProperty("Resource Link")]
        public Uri ResourceLink { get; set; }

        [JsonProperty("DHH Quote")]
        public string DhhQuote { get; set; }

        [JsonProperty("DHH Name")]
        public string DhhName { get; set; }

        [JsonProperty("DHH Photo")]
        public string DhhPhoto { get; set; }

        [JsonProperty("Parent Photo")]
        public string ParentPhoto { get; set; }

        [JsonProperty("ResourceImage")]
        public string ResourceImage { get; set; }

        [JsonProperty("ArticleImage")]
        public string ArticleImage { get; set; }
        #endregion

        #region Properties
        public string ResourceTopic { get => TrimLength(ResourcesToExplore); }
        public string DhhTopic { get => TrimLength(DhhName); }
        public string ParentTopic { get => TrimLength(ParentName); }
        public string Topic { get => TrimLength(TitleTopic); }
        public string DayString { get => "Day " + Day.ToString(); }
        public bool IsNew { get => DetermineItemIsNew(Day); }
        public bool IsVisible { get => DaySignDisappear(Day); }
        #endregion

        #region Methods
        string TrimLength(string _topic)
        {
            var str = (_topic.Length >= 23) ? _topic.Substring(0, 23) + "..." : _topic;
            return str;
        }

        async void CleanCache(string _image)
        {
            await CachedImage.InvalidateCache(_image, CacheType.All, true);
        }

        bool DetermineItemIsNew(long _day)
        {
            var isNew = (_day == App.DayCount);
            return isNew;
        }

        bool DaySignDisappear(long _day)
        {
            var isItem = (_day != 0);
            return isItem;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HandsAndVoices.Models
{
    public class Article
    {
        [PrimaryKey]
        public int Day { get; set; }

        public string Topic { get; set; }

        public string ParentParagraph { get; set; }

        public string ParentLinks { get; set; }

        public string ParentName { get; set; }

        public string ParentQuote { get; set; }

        public string ParentImage { get; set; }

        public string ResourceParagraph { get; set; }

        public string ResourceLinks { get; set; }

        public string DhhName { get; set; }

        public string DhhQuote { get; set; }

        public string DhhImage { get; set; }

        public Article()
        {
            
        }

        public Article(int day, string topic, string parentParagraph, string parentLinks, string parentName, string parentQuote, string parentImage, string resourceParagraph, string resourceLinks, string dhhName, string dhhQuote, string dhhImage)
        {
            Day = day;
            Topic = topic;
            ParentParagraph = parentParagraph;
            ParentLinks = parentLinks;
            ParentName = parentName;
            ParentQuote = parentQuote;
            ParentImage = parentImage;
            ResourceParagraph = resourceParagraph;
            ResourceLinks = resourceLinks;
            DhhName = dhhName;
            DhhQuote = dhhQuote;
            DhhImage = dhhImage;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HandsAndVoices.Model
{
    public class UserConfig
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string StartUp { get; set; }

        public UserConfig()
        {
            
        }

        public UserConfig(string startUp)
        {
            StartUp = startUp;
        }
    }
}

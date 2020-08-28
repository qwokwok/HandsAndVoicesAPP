using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using HandsAndVoices.Models;

namespace HandsAndVoices.Server
{
    public class ArticleRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public ArticleRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Article>().Wait();
            _database.CreateTableAsync<UserConfig>().Wait();
            InitializationArticleDatabase();
        }

        public void InitializationArticleDatabase()
        {
            var counts = Convert.ToInt32(_database.Table<Article>().CountAsync());
            if (counts < 0)
            {
                ImportData();
            }
        }

        private void ImportData()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            using Stream dataFile = assembly.GetManifestResourceStream("HandsAndVoices.Data.90DatasInfo.tsv");

            using StreamReader sr = new StreamReader(dataFile ?? throw new InvalidOperationException());

            while (sr.ReadLine() != null)
            {
                var str = sr.ReadLine();
                var strSplit = str?.Split('\t');

                _database.InsertAsync(new Article(
                    Convert.ToInt32(strSplit?[0]),
                    strSplit?[1],
                    strSplit?[2],
                    strSplit?[3],
                    strSplit?[4],
                    strSplit?[5],
                    strSplit?[6],
                    strSplit?[7],
                    strSplit?[8],
                    strSplit?[9],
                    strSplit?[10],
                    strSplit?[11])
                );
            }
        }

        public Task<List<Article>> OnGetListAsync(string date)
        {
            return _database.Table<Article>().Where(i => i.Day <= CalculateTotalDays(date)).ToListAsync();
        }

        public double CalculateTotalDays(string date)
        {
            return Math.Floor((DateTime.Now - DateTime.Parse(date)).TotalDays);
        }
    }
}

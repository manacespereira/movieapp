using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieApp.Models;
using SQLite;

namespace MovieApp.Helpers
{
    public class Repository
    {
        protected readonly SQLiteConnection Connection;

        public Repository()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MovieDB.db3");
            Connection = new SQLiteConnection(dbPath);
            Connection.CreateTable<Genre>();
        }

        public void AddGenres(List<Genre> genres)
        {
            Connection.InsertAll(genres);
        }

        public List<Genre> GetGenresByIdList(List<int> ids)
        {
            return Connection.Table<Genre>().Where(x => ids.Contains(x.Id)).ToList();
        }

        public bool GenresWasLoaded()
        {
            return Connection.Table<Genre>().Any();
        }


    }
}

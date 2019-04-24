using MovieApp.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Models
{
    public class Movie
    {
        private readonly Repository repo;

        public Movie()
        {
            repo = new Repository();
        }

        public int Id { get; set; }

        public string BackdropPath { get; set; }

        public string PosterPath { get; set; }

        public double Budget { get; set; }

        public string IMDbId { get; set; }

        public string Overview { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string Title { get; set; }

        public IEnumerable<int> GenreIds { get; set; }

        [JsonIgnore]
        public IEnumerable<Genre> Genres => repo.GetGenresByIdList(GenreIds.ToList());

        [JsonIgnore]
        public string BackdropSourceImage => $"{Consts.BASE_IMAGE_URL}{BackdropPath}";

        [JsonIgnore]
        public string PosterSourceImage => $"{Consts.BASE_IMAGE_URL}{PosterPath}";
    }
}

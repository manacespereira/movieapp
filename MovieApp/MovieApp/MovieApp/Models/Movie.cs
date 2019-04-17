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

        [JsonProperty("backdrop_path")]
        public string BackdropIncompletePath { get; set; }

        [JsonProperty("poster_path")]
        public string PosterIncompletePath { get; set; }

        public double Budget { get; set; }

        [JsonProperty("imdb_id")]
        public string IMDbId { get; set; }

        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }

        public string Title { get; set; }

        [JsonProperty("genre_ids")]
        public IEnumerable<int> GenreIds { get; set; }

        [JsonIgnore]
        public IEnumerable<Genre> Genres => repo.GetGenresByIdList(GenreIds.ToList());

        [JsonIgnore]
        public string BackdropPath => $"{Consts.BASE_IMAGE_URL}{BackdropIncompletePath}";

        [JsonIgnore]
        public string PosterPath => $"{Consts.BASE_IMAGE_URL}{PosterIncompletePath}";
    }
}

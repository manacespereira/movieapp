using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        public double Budget { get; set; }

        [JsonProperty("imdb_id")]
        public string IMDbId { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }

        public int Revenue { get; set; }

        public int Runtime { get; set; }

        public EStatus Status { get; set; }

        public string Tagline { get; set; }

        public string Title { get; set; }

        public bool Video { get; set; }

        [JsonProperty("video_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("video_count")]
        public int VoteCount { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        [JsonProperty("production_companies")]
        public IEnumerable<ProductionCompany> ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public IEnumerable<ProductionCountry> ProductionCountries { get; set; }

        [JsonProperty("spoken_languages")]
        public IEnumerable<Language> SpokenLanguages { get; set; }
    }
}

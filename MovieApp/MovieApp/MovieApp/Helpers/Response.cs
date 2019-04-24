using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieApp.Helpers
{
    public class Response<T> where T : class
    {
        public int Page { get; set; }

        [JsonProperty("total_resutls")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public T Results { get; set; }

        // Used to ger Genre endpoint response
        public T Genres { get; set; }
    }
}

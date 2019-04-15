﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieApp.Models
{
    public class Response<T> where T : class
    {
        public int Page { get; set; }

        [JsonProperty("total_resutls")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}

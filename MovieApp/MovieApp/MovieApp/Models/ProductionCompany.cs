using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Models
{
    public class ProductionCompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }
    }
}

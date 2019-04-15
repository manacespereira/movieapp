using Newtonsoft.Json;

namespace MovieApp.Models
{
    public class ProductionCountry
    {
        [JsonProperty("iso_3166_1")]
        public string ISO31661 { get; set; }
        public string Name { get; set; }
    }
}
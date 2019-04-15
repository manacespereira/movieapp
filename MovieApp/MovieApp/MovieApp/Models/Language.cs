using Newtonsoft.Json;

namespace MovieApp.Models
{
    public class Language
    {
        [JsonProperty("iso_639_1")]
        public string ISO6391 { get; set; }
        public string Name { get; set; }
    }
}
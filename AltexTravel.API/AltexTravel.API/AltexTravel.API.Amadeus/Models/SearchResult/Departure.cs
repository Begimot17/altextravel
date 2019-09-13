using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Departure
    {
        [JsonProperty("iataCode")]
        public string iataCode { get; set; }

        [JsonProperty("terminal")]
        public string terminal { get; set; }

        [JsonProperty("at")]
        public string at { get; set; }
    }
}
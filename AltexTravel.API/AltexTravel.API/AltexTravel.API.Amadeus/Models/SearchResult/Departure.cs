using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Departure
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("terminal")]
        public string Terminal { get; set; }

        [JsonProperty("at")]
        public string At { get; set; }
    }
}
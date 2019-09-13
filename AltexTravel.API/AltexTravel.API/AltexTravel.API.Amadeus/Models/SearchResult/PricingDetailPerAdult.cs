using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class PricingDetailPerAdult
    {
        [JsonProperty("travelClass")]
        public string travelClass { get; set; }

        [JsonProperty("fareClass")]
        public string fareClass { get; set; }

        [JsonProperty("availability")]
        public int availability { get; set; }

        [JsonProperty("fareBasis")]
        public string fareBasis { get; set; }
    }
}
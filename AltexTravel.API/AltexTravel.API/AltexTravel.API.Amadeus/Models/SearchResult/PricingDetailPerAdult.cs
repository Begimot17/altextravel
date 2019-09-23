using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class PricingDetailPer
    {
        [JsonProperty("travelClass")]
        public string TravelClass { get; set; }

        [JsonProperty("fareClass")]
        public string FareClass { get; set; }

        [JsonProperty("availability")]
        public int Availability { get; set; }

        [JsonProperty("fareBasis")]
        public string FareBasis { get; set; }
    }
}
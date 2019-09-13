using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class PricePerAdult
    {
        [JsonProperty("total")]
        public double total { get; set; }

        [JsonProperty("totalTaxes")]
        public double totalTaxes { get; set; }
    }
}
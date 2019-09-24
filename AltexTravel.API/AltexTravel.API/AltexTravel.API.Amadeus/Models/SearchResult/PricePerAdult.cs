using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class PricePerAdult
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("totalTaxes")]
        public decimal TotalTaxes { get; set; }
    }
}
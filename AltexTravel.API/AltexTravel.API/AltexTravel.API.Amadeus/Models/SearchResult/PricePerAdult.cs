using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class PricePerAdult
    {
        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("totalTaxes")]
        public double TotalTaxes { get; set; }
    }
}
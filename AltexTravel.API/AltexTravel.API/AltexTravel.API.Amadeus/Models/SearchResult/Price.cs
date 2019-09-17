using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Price
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("totalTaxes")]
        public double TotalTaxes { get; set; }
    }
}
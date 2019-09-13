using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Price
    {
        [JsonProperty("total")]
        public double total { get; set; }

        [JsonProperty("totalTaxes")]
        public double totalTaxes { get; set; }
    }
}
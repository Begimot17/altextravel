using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Operating
    {
        [JsonProperty("carrierCode")]
        public string carrierCode { get; set; }

        [JsonProperty("number")]
        public int number { get; set; }
    }
}
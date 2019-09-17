using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Operating
    {
        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }
    }
}
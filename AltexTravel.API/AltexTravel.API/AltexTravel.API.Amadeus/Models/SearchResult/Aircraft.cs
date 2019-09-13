using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Aircraft
    {
        [JsonProperty("code")]
        public string code { get; set; }
    }
}
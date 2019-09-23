using Newtonsoft.Json;
using System.Collections.Generic;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Dictionaries
    {
        [JsonProperty("carriers")]
        public Dictionary<string,string> Carriers { get; set; }
        [JsonProperty("currencies")]
        public Dictionary<string,string> Currencies { get; set; }
        [JsonProperty("aircraft")]
        public Dictionary<string,string> Aircraft { get; set; }
        [JsonProperty("locations")]
        public Dictionary<string,string> Locations { get; set; }
    }
}
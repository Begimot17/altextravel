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
        public Dictionary<string,Location> Locations { get; set; }
    }

    public class Location
    {
        [JsonProperty("subType")]
        public string SubType  { get; set; }

        [JsonProperty("detailedName")]
        public string DetailedName  { get; set; }
    }
}
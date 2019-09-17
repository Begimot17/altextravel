using Newtonsoft.Json;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Locations
    {
        //ADD DICTIONARY
        [JsonProperty("subType")]
        public string SubType { get; set; }

        [JsonProperty("detailedName")]
        public string DetailedName { get; set; }
    }
}
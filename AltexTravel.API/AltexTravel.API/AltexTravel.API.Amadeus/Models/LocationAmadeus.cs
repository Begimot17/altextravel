using Newtonsoft.Json;
using System.Collections.Generic;

namespace AltexTravel.API.Amadeus.Models
{
    public class LocationAmadeus
    {
        [JsonProperty("subType")]
        public string Type { get; set; }
        [JsonProperty("address")]
        public AddressModel Address { get; set; }
        public List<IataAmadeus> Airports { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.Amadeus
{
    public class AmadeusModel
    {
        [JsonProperty("data")]
        public List<LocationAmadeus> Data { get; set; }
    }
    public class LocationAmadeus
    {
        [JsonProperty("subType")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("iataCode")]
        public string Code { get; set; }
        public List<IataAmadeus> Airports { get; set; }
    }
    public class IataAmadeus
    { 
        public string Name { get; set; }
        public string Code { get; set; }
    }
}

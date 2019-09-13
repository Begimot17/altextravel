using Newtonsoft.Json;
using System.Collections.Generic;

namespace AltexTravel.API.Amadeus.Models
{
    public class AmadeusModel
    {
        [JsonProperty("data")]
        public List<LocationAmadeus> Data { get; set; }
    }
}

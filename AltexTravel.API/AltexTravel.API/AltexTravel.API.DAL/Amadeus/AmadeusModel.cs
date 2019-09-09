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
}

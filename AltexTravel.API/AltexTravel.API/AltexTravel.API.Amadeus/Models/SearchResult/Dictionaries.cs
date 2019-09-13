using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Dictionaries
    {
        [JsonProperty("locations")]
        public Locations locations { get; set; }

        [JsonProperty("carriers")]
        public Carriers carriers { get; set; }

        [JsonProperty("currencies")]
        public Currencies currencies { get; set; }

        [JsonProperty("aircraft")]
        public Aircraft aircraft { get; set; }
    }
}

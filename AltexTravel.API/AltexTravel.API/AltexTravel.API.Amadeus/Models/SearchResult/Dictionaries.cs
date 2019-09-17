using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Dictionaries
    {
        [JsonProperty("locations")]
        public Locations Locations { get; set; }

        [JsonProperty("carriers")]
        public Carriers Carriers { get; set; }

        [JsonProperty("currencies")]
        public Currencies Currencies { get; set; }

        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }
    }
}

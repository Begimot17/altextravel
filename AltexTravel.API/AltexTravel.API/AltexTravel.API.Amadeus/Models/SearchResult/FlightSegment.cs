using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class FlightSegment
    {
        [JsonProperty("departure")]
        public Departure departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival arrival { get; set; }

        [JsonProperty("carrierCode")]
        public string carrierCode { get; set; }

        [JsonProperty("number")]
        public int number { get; set; }

        [JsonProperty("aircraft")]
        public Aircraft aircraft { get; set; }

        [JsonProperty("operating")]
        public Operating operating { get; set; }

        [JsonProperty("duration")]
        public string duration { get; set; }
    }
}

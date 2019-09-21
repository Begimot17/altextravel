using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class FlightSegment
    {
        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }

        [JsonProperty("operating")]
        public Operating Operating { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }
    }
}

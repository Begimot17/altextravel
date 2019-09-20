using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Segment
    {
        [JsonProperty("flightSegment")] 
        public FlightSegment FlightSegment { get; set; }

        [JsonProperty("pricingDetailPerAdult")]
        public PricingDetailPerAdult PricingDetailPerAdult { get; set; }
    }
}

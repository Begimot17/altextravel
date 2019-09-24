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
        public PricingDetail PricingDetailPerAdult { get; set; }

        [JsonProperty("pricingDetailPerChild")]
        public PricingDetail PricingDetailPerChild { get; set; }

        [JsonProperty("pricingDetailPerInfant")]
        public PricingDetail PricingDetailPerInfant { get; set; }
    }
}

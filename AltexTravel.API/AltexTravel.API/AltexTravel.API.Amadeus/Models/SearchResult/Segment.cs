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
        public PricingDetailPer PricingDetailPerAdult { get; set; }

        [JsonProperty("pricingDetailPerChild")]
        public PricingDetailPer PricingDetailPerChild { get; set; }

        [JsonProperty("pricingDetailPerInfant")]
        public PricingDetailPer PricingDetailPerInfant { get; set; }
    }
}

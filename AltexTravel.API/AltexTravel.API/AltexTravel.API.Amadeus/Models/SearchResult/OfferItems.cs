using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class OfferItems
    {
        [JsonProperty("services")]
        public List<Services> Services { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("pricePerAdult")]
        public PricePerAdult PricePerAdult { get; set; }
    }
}

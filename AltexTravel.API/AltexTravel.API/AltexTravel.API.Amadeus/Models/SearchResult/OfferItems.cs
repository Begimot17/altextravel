using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class OfferItems
    {
        [JsonProperty("services")]
        public List<Services> services { get; set; }

        [JsonProperty("price")]
        public Price price { get; set; }

        [JsonProperty("pricePerAdult")]
        public PricePerAdult pricePerAdult { get; set; }
    }
}

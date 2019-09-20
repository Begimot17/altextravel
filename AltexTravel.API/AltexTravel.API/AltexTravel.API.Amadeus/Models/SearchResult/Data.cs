using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Data
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("offerItems")]
        public List<OfferItems> OfferItems { get; set; }


    }
}

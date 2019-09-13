using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Data
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("offerItems")]
        public List<OfferItems> offerItems { get; set; }

        [JsonProperty("dictionaries")]
        public Dictionaries dictionaries { get; set; }
    }
}

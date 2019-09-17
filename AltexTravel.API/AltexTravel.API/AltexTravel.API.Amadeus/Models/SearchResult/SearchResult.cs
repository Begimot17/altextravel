using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class SearchResult
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }
}

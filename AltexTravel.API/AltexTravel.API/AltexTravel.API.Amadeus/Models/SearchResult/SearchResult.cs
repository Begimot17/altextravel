using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class AmadeusSearchResult
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
        
    }
}

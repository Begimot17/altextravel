using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models.SearchResult
{
    public class Services
    {
        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Models
{
    public class AddressModel
    {
        [JsonProperty("cityName")]
        public string Name { get; set; }
        [JsonProperty("cityCode")]
        public string Code { get; set; }
        [JsonProperty("countryName")]
        public string Country { get; set; }
    }
}

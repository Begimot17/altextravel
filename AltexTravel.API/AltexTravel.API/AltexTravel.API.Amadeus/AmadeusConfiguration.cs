using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus
{
    public class AmadeusConfiguration
    {
        public string UrlLocations { get; set; }
        public string Apikey { get; set; }
        public string Apisecret { get; set; }
        public string TokenURL { get; set; }
        public string BaseUrl { get; set; }
        //public string Post => $"grant_type=client_credentials&client_id={Apikey}&client_secret={Apisecret}";
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus
{
    public class AmadeusConfiguration
    {
        public string UrlLocations = "https://test.api.amadeus.com/v1/reference-data/locations?subType=AIRPORT,CITY&keyword=r&page[limit]=5000";
        public string Apikey = "gZCS7tiyaRIIVihAoQFo2vARev7AnAVh";
        public string Apisecret = "yb3SXyWAeLGblN8K";
        public string TokenURL = "https://test.api.amadeus.com/v1/security/oauth2/token";
        public string BaseUrl = "https://test.api.amadeus.com/v1/";
        public string Post => $"grant_type=client_credentials&client_id={Apikey}&client_secret={Apisecret}";
    }
}

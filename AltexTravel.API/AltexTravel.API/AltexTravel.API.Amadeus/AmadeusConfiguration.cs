using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus
{
    public class AmadeusConfiguration
    {
        public const string UrlLocations = "https://test.api.amadeus.com/v1/reference-data/locations?subType=AIRPORT,CITY&keyword=r&page[limit]=5000";
        public const string Apikey = "gZCS7tiyaRIIVihAoQFo2vARev7AnAVh";
        public const string Apisecret = "yb3SXyWAeLGblN8K";
        public const string TokenURL = "https://test.api.amadeus.com/v1/security/oauth2/token";
        public const string BaseUrl = "https://test.api.amadeus.com/v1/";
        public static string Post => $"grant_type=client_credentials&client_id={Apikey}&client_secret={Apisecret}";
    }
}

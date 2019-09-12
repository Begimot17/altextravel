using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus
{
    public class AmadeusConfiguration
    {
        //public string UrlLocations => $"{BaseUri}reference-data/locations?subType=AIRPORT,CITY&keyword=r&page[limit]=5000";
        //public string Apikey = "gZCS7tiyaRIIVihAoQFo2vARev7AnAVh";
        //public string Apisecret = "yb3SXyWAeLGblN8K";
        //public string TokenURL => $"{BaseUri}security/oauth2/token";
        //public string BaseUri = "https://test.api.amadeus.com/v1/";
        //public string Post => $"grant_type=client_credentials&client_id={Apikey}&client_secret={Apisecret}";
        public string UrlLocationsPath { get; set; }
        public string UrlLocations => BaseUrl + UrlLocationsPath;

        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string TokenUrlPath { get; set; }
        public string TokenUrl => BaseUrl + TokenUrlPath;

        public string BaseUrl { get; set; }
        public string TokenUrlQueryParams { get; set; }
        public string TokenUrlQuery => BaseUrl + String.Format(TokenUrlQueryParams, ApiKey, ApiSecret);
    }
}

using System;

namespace AltexTravel.API.Amadeus
{
    public class AmadeusConfiguration
    {

        public string UrlLocationsPath { get; set; }
        public string UrlLocations => BaseUrl + UrlLocationsPath;
        public string UrlSearchPath { get; set; }
        public string UrlSearch => BaseUrl + UrlSearchPath;

        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string TokenUrlPath { get; set; }
        public string TokenUrl => BaseUrl + TokenUrlPath;

        public string BaseUrl { get; set; }
        public string TokenUrlQueryParams { get; set; }
        public string TokenUrlQuery => String.Format(TokenUrlQueryParams, ApiKey, ApiSecret);
    }
}

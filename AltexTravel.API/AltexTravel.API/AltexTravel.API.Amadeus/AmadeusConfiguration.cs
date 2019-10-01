using System;
using System.Collections.Generic;

namespace AltexTravel.API.Amadeus
{
    public class AmadeusConfiguration
    {
        public string UrlLocationsPath { get; set; }
        public IEnumerable<char> Keywords = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public char Keyword { get; set; }
        public string UrlLocations => BaseUrl + String.Format(UrlLocationsPath, Keyword);
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

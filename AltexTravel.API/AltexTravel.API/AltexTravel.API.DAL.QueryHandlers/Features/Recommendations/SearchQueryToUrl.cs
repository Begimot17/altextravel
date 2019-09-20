using AltexTravel.API.DAL.Queries.Features.Recommendations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public static class SearchQueryToUrl
    {
        public static string GetUrlPath(RecommendationQuery query)
        {
            var urlPath = new StringBuilder();
            if (query.CurrencyCode != null)
                urlPath.Append(QueryToPath("currency", query.CurrencyCode));
            if (query.NumberOfAdults != 0)
                urlPath.Append(QueryToPath("adults", query.NumberOfAdults));
            if (query.NumberOfChildren != 0)
                urlPath.Append(QueryToPath("children", query.NumberOfChildren));
            if (query.NumberOfInfants != 0)
                urlPath.Append(QueryToPath("infants", query.NumberOfInfants));
            return urlPath.ToString().TrimEnd('&');
        }
        public static string QueryToPath(string key, string value) =>
             $"{key}={value}&";
        public static string QueryToPath(string key, int value) =>
             $"{key}={value}&";
        public static string QueryToPath(string key, bool value) =>
             $"{key}={value.ToString()}&";

    }
}

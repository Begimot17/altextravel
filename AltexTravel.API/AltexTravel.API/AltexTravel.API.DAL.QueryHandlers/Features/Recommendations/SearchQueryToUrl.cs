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
            urlPath.Append(QueryToPath("origin", query.ArrivalPort));
            urlPath.Append(QueryToPath("destination", query.DeparturePort));
            urlPath.Append(QueryToPath("departureDate", query.DepartureDate.ToString("yyyy-MM-dd")));
            urlPath.Append(QueryToPath("returnDate", query.ReturnDate.ToString("yyyy-MM-dd")));
            if (query.NumberOfAdults != 0)
                urlPath.Append(QueryToPath("adults", query.NumberOfAdults));
            if (query.NumberOfChildren != 0)
                urlPath.Append(QueryToPath("children", query.NumberOfChildren));
            if (query.NumberOfInfants != 0)
                urlPath.Append(QueryToPath("infants", query.NumberOfInfants));
            urlPath.Append(QueryToPath("travelClass", query.Cabin.ToString()));
            if (query.CurrencyCode != null)
                urlPath.Append(QueryToPath("currency", query.CurrencyCode));

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

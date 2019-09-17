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
            if (query.ArrivalPort != null)
                urlPath.Append(QueryToPath("origin", query.ArrivalPort));
            if (query.Cabin != null)
                urlPath.Append(QueryToPath("travelClass", query.Cabin));
            if (query.CurrencyCode != null)
                urlPath.Append(QueryToPath("currency", query.CurrencyCode));
            if (query.DepartureDate != null)
                urlPath.Append(QueryToPath("departureDate", query.DepartureDate));
            if (query.DeparturePort != null)
                urlPath.Append(QueryToPath("destination", query.DeparturePort));
            if (query.NumberOfAdults != 0)
                urlPath.Append(QueryToPath("adults", query.NumberOfAdults));
            if (query.NumberOfChildren != 0)
                urlPath.Append(QueryToPath("children", query.NumberOfChildren));
            if (query.NumberOfInfants != 0)
                urlPath.Append(QueryToPath("infants", query.NumberOfInfants));
            if (query.ReturnDate != null)
                urlPath.Append(QueryToPath("returnDate", query.ReturnDate));
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

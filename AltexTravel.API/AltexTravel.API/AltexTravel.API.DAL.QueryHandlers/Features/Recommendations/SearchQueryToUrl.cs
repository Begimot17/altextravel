using AltexTravel.API.DAL.Queries.Features.Recommendations;
using Flurl;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public static class SearchQueryToUrl
    {
        public static Dictionary<string, object> GetQueryParams(this RecommendationQuery query)
        {
            var queryParams = new Dictionary<string, object>();
            queryParams.Add("origin", query.ArrivalPort);
            queryParams.Add("destination", query.DeparturePort);
            queryParams.Add("departureDate", query.DepartureDate.ToString("yyyy-MM-dd"));
            queryParams.Add("returnDate", query.ReturnDate.ToString("yyyy-MM-dd"));
            queryParams.Add("travelClass", query.Cabin.ToString());
            if (query.NumberOfAdults != 0)
                queryParams.Add("adults", query.NumberOfAdults);
            if (query.NumberOfChildren != 0)
                queryParams.Add("children", query.NumberOfChildren);
            if (query.NumberOfInfants != 0)
                queryParams.Add("infants", query.NumberOfInfants);
            if (query.CurrencyCode != null)
                queryParams.Add("currency", query.CurrencyCode);
            return queryParams; 
        }
    }
}

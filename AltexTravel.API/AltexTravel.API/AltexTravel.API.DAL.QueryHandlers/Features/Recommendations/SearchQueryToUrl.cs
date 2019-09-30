using AltexTravel.API.DAL.Queries.Features.Recommendations;
using System.Collections.Generic;

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
                queryParams.Add("adults", query.NumberOfAdults);
                queryParams.Add("children", query.NumberOfChildren);
                queryParams.Add("infants", query.NumberOfInfants);
                queryParams.Add("currency", query.CurrencyCode);
            return queryParams; 
        }
    }
}

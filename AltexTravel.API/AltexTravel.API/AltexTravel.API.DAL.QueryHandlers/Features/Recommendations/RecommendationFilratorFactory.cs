﻿using AltexTravel.API.DAL.Queries.Features.Recommendations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public static class RecommendationFilratorFactory
    {
        public static RecommendationQueryResponce ReccomendationFilrator(this RecommendationQueryResponce recommendations, RecommendationQuery query)
        {
            recommendations.FullRecommendations=recommendations.FullRecommendations
                        .FilterByMinPrice(query.MinPrice)
                        .FilterByAirlines(query.Airlines)
                        .FilterByArrival(query.Arrival)
                        .FilterByDeparture(query.Departure)
                        .FilterByMaxPrice(query.MaxPrice)
                        .FilterByNumberOfStops(query.NumberOfStops)
                        .FilterByDuration(query.Duration);
            return recommendations;
        }
    }
}

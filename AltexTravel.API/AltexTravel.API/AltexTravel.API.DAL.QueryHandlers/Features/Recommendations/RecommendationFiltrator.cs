using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Domain.RecomendationsModel;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public static class RecommendationFiltrator
    {
        public static List<Recommendation> FilterByMinPrice(this List<Recommendation> recommendations, decimal minPrice)
        {
            if (minPrice != 0)
                return recommendations.Where(x => x.PriceDetails
                    .All(y => y.Total >= minPrice))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByMaxPrice(this List<Recommendation> recommendations, decimal maxPrice)
        {
            if (maxPrice != 0)
                return recommendations.Where(x => x.PriceDetails
                    .All(y => y.Total <= maxPrice))
                    .ToList();
            return recommendations;
        }
        public static List<Recommendation> FilterByAirlines(this List<Recommendation> recommendations, List<string> airlines)
        {
            if (airlines != null)
                return recommendations.Where(x => x.Segments
                    .All(y => y.Flights
                    .All(z => airlines
                    .Any(q => q == z.MarketingCarrier.Name
                      || q == z.OperatingCarrier.Name))))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByArrival(this List<Recommendation> recommendations, List<string> arrivals)
        {
            if (arrivals != null)
                return recommendations.Where(x => x.Segments
                    .All(y => y.Flights
                    .All(z => arrivals
                    .Any(q => q == z.Route.ArrivalPort.Name))))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByDeparture(this List<Recommendation> recommendations, List<string> departure)
        {
            if (departure != null)
                return recommendations.Where(x => x.Segments
                    .All(y => y.Flights
                    .All(z => departure
                    .Any(q => q == z.Route.DeparturePort.Name))))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByDuration(this List<Recommendation> recommendations, TimeSpan duration)
        {
            if (duration > new TimeSpan(0,0,0) )
                return recommendations.Where(x => x.Segments
                    .All(y => y.Flights
                    .All(q => duration == q.FlyingTime))).ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByNumberOfStops(this List<Recommendation> recommendations, List<NumberOfStops> numberOfStops)
        {
            if (numberOfStops != null)
                return recommendations.Where(x => x.Segments
                .All(y => numberOfStops
                .Any(z => (byte)z == y.Flights.Count  
                || ((byte)z == 3 && y.Flights.Count >= 3)))).ToList();
            return recommendations;
        }


    }
}

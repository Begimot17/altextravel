using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Domain.RecomendationsModel;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public static class RecommendationFiltratorBuilder
    {
        public static List<Recommendation> FilterByMinPrice(this List<Recommendation> recommendations, decimal minPrice)
        {
            if (minPrice != 0)
                return recommendations.Where(rec => rec.PriceDetails
                    .All(price => price.Total >= minPrice))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByMaxPrice(this List<Recommendation> recommendations, decimal maxPrice)
        {
            if (maxPrice != 0)
                return recommendations.Where(rec => rec.PriceDetails
                    .All(price => price.Total <= maxPrice))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByAirlines(this List<Recommendation> recommendations, List<string> airlines)
        {
            if (airlines != null)
                return recommendations.Where(rec => rec.Segments
                    .All(seg => seg.Flights
                    .All(fly => airlines
                    .Any(air => air == fly.MarketingCarrier.Name
                      || air == fly.OperatingCarrier.Name))))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByArrival(this List<Recommendation> recommendations, List<string> arrivals)
        {
            if (arrivals != null)
                return recommendations.Where(rec => rec.Segments
                    .All(seg => seg.Flights
                    .All(fly => arrivals
                    .Any(name => name == fly.Route.ArrivalPort.Name))))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByDeparture(this List<Recommendation> recommendations, List<string> departure)
        {
            if (departure != null)
                return recommendations.Where(rec => rec.Segments
                    .All(seg => seg.Flights
                    .All(fly => departure
                    .Any(name => name == fly.Route.DeparturePort.Name))))
                    .ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByDuration(this List<Recommendation> recommendations, TimeSpan duration)
        {
            if (duration > new TimeSpan(0, 0, 0))
                return recommendations.Where(rec => rec.Segments
                    .All(seg => seg.Flights
                    .All(fly => duration >= fly.FlyingTime))).ToList();
            return recommendations;
        }

        public static List<Recommendation> FilterByNumberOfStops(this List<Recommendation> recommendations, List<NumberOfStops> numberOfStops)
        {
            if (numberOfStops != null)
                return recommendations.Where(rec => rec.Segments
                .All(seg => numberOfStops
                .Any(ns => ns.ToFlights() == seg.Flights.Count
                || (ns == NumberOfStops.ManyStops && seg.Flights.Count >= NumberOfStops.ManyStops.ToFlights())))).ToList();
            return recommendations;
        }

        public static byte ToFlights(this NumberOfStops num) =>
            (byte)num++;
    }
}

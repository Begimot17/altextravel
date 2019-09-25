using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Domain.RecomendationsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public static class FiltrationManager
    {
        public static List<NumberOfStops> NumberOfStops { get; set; }
        public static decimal MaxPrice { get; set; }
        public static decimal MinPrice { get; set; }
        public static List<string> Airlines { get; set; }
        public static List<string> Arrival { get; set; }
        public static List<string> Departure { get; set; }
        public static TimeSpan Duration { get; set; }
        public static RecommendationQueryResponce GetFiltration(this RecommendationQueryResponce model, RecommendationQuery query)
        {
            NumberOfStops = query.NumberOfStops;
            MaxPrice = query.MaxPrice;
            MinPrice = query.MinPrice;
            Airlines = query.Airlines;
            Arrival = query.Arrival;
            Departure = query.Departure;
            Duration = query.Duration;
            model.FullRecommendations = model.FullRecommendations.GetFiltration().Where(y => y != null).ToList();
            return model;
        }
        public static List<Recommendation> GetFiltration(this List<Recommendation> model)
        {
            return model.Select(x => x.GetFiltration()).ToList().Where(y => y != null).ToList();
        }
        public static Recommendation GetFiltration(this Recommendation model)
        {
            if (MaxPrice != 0)
                if (model.PriceDetails.Any(x => x.Total >= MaxPrice))
                    return null;

            if (MinPrice != 0)
                if (model.PriceDetails.Any(x => x.Total <= MinPrice))
                    return null;

            var segments = model.Segments.Select(x => x.GetFiltration()).ToList();
            if (segments.Any(x => x == null))
                return null;

            if (model.Segments.Any(x => x.GetFiltration() == null))
                return null;
            return model;
        }
        public static Segment GetFiltration(this Segment model)
        {
            if (NumberOfStops != null)
            {
                int count = model.Flights.Count;
                if (count > 3)
                    count = 3;

                if (NumberOfStops.All(x => x.GetHashCode() != count))
                    return null;
            }

            if (Duration != null)
                if (model.Flights.Any(x => x.FlyingTime <= Duration))
                    return null;

            if (Airlines != null)
                foreach (var airs in Airlines)
                {
                    if (model.Flights.Any(x => x.MarketingCarrier.Name != airs || x.OperatingCarrier.Name != airs))
                        return null;
                }

            return model;
        }
    }
}

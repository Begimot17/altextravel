using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Domain.RecomendationsModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AltexTravel.API.DAL.Features.SearchResult
{
    public static class LocationsFromDb
    {
        public static RecommendationQueryResponce GetLocation(this RecommendationQueryResponce model,TravelContext context) =>
            new RecommendationQueryResponce
            {
                FullRecommendations = model.FullRecommendations.Select(x=>x.ToLocation(context)).ToList()
            };

        public static Recommendation ToLocation(this Recommendation model,TravelContext context) =>
            new Recommendation
            {
                PriceDetails = model.PriceDetails,
                CachedFlightReference=model.CachedFlightReference,
                Segments=model.Segments.Select(x=>x.ToLocation(context)).ToList()
            };

        public static Segment ToLocation(this Segment model,TravelContext context) =>
            new Segment
            {
                Flights = model.Flights.Select(x => x?.ToLocation(context)).ToList(),
            };

        public static Flight ToLocation(this Flight model,TravelContext context)
        {
            return new Flight
            {
                EquipmentType = new EquipmentType
                {
                    Code = model.EquipmentType.Code,
                    Name = model.EquipmentType.Name
                },
                FreeBaggage = model.FreeBaggage,
                Layover = model.Layover,
                Rules = model.Rules,

                ElapseFlyingTime = model.ElapseFlyingTime,

                ArrivalTime = model.ArrivalTime,
                DepartureTime = model.DepartureTime,
                Cabin = model.Cabin,
                FareBasis = model.FareBasis,
                FlightNumber = model.FlightNumber,
                FlyingTime = model.FlyingTime,
                MarketingCarrier = new Airline
                {
                    Code = model.MarketingCarrier.Code,
                    Name = model.MarketingCarrier.Name

                },
                OperatingCarrier = new Airline
                {
                    Code = model.OperatingCarrier.Code,
                    Name = model.OperatingCarrier.Name
                },
                Route = new AirportPair
                {
                    ArrivalPort = GetAirport(context, model.Route.ArrivalPort.Code),
                    DeparturePort = GetAirport(context,model.Route.DeparturePort.Code)
                }
            };
        }

        public static Airport GetAirport(TravelContext context,string code)
        {
            var airdefault = new Airport
            {
                City=new City
                {
                    Code = "---",
                    CountryCode = "---",
                    Name = "---"
                },
                Code = code,
                Name = "---",
            };
            var air = context.IataCodes
                .AsNoTracking()
                .Include(x => x.Location)
                .FirstOrDefault(x=>x.Code==code).ToAir()?? airdefault;
            return air;
        }
        public static Airport ToAir(this IataCode model) =>
            new Airport
            {
                Code = model.Code,
                Name = model.Name,
                City = new City
                {
                    Code = model.Location.Code,
                    Name = model.Location.Name,
                    CountryCode = "---"
                }
            };
    }
}

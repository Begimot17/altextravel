using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Models.SearchResult;
using System.Collections.Generic;
using System.Linq;
using Domain = AltexTravel.API.Domain.RecomendationsModel;

namespace AltexTravel.API.Mappers
{
    public static class SearchResultMapper
    {
        public static RecommendationsViewModel ToViewModel(this RecommendationQueryResponce model) =>
            new RecommendationsViewModel
            {
                Recommendations = model.FullRecommendations.Select(x => x?.ToViewModel()).ToList()
            };

        public static Recommendation ToViewModel(this Domain::Recommendation model) =>
            new Recommendation
            {
                CachedFlightReference = model.CachedFlightReference,
                PriceDetails = model.PriceDetails.ToViewModel(),
                Segments = model.Segments?.ToViewModel()
            };

        public static List<PriceInfo> ToViewModel(this List<Domain::PriceInfo> model) =>
            model.Select(x => x?.ToViewModel()).ToList();

        public static PriceInfo ToViewModel(this Domain::PriceInfo model) => new PriceInfo
        {
            DataSource = model.DataSource,
            PriceByPassengerType = new PriceByPassengerType
            {
                Adult = model.PriceByPassengerType.Adult == null ? new PriceDetails
                {
                    BaseFare = model.PriceByPassengerType.Adult.BaseFare,
                    NumberOfPassengers = model.PriceByPassengerType.Adult.NumberOfPassengers,
                    Total = model.PriceByPassengerType.Adult.Total,
                    Taxes = model.PriceByPassengerType.Adult.Taxes,
                    Fees = model.PriceByPassengerType.Adult.Fees,
                } : null,
                Child = model.PriceByPassengerType.Adult == null ? new PriceDetails
                {
                    BaseFare = model.PriceByPassengerType.Child.BaseFare,
                    NumberOfPassengers = model.PriceByPassengerType.Child.NumberOfPassengers,
                    Total = model.PriceByPassengerType.Child.Total,
                    Taxes = model.PriceByPassengerType.Child.Taxes,
                    Fees = model.PriceByPassengerType.Child.Fees,
                } : null,
                Infant = model.PriceByPassengerType.Adult == null ? new PriceDetails
                {
                    BaseFare = model.PriceByPassengerType.Infant.BaseFare,
                    NumberOfPassengers = model.PriceByPassengerType.Infant.NumberOfPassengers,
                    Total = model.PriceByPassengerType.Infant.Total,
                    Taxes = model.PriceByPassengerType.Infant.Taxes,
                    Fees = model.PriceByPassengerType.Infant.Fees,
                } : null
            },
            Total = model.Total
        };

        public static List<Segment> ToViewModel(this List<Domain::Segment> model) =>
            model.Select(x => x?.ToViewModel()).ToList();

        public static Segment ToViewModel(this Domain::Segment model) =>
            new Segment
            {
                Flights = model.Flights.Select(x => x?.ToViewModel()).ToList()
            };

        public static Flight ToViewModel(this Domain::Flight model) =>
            new Flight
            {
                ElapseFlyingTime = model.ElapseFlyingTime,
                ArrivalTime = model.ArrivalTime,
                DepartureTime = model.DepartureTime,
                Cabin = model.Cabin,
                FareBasis = model.FareBasis,
                FlyingTime = model.FlyingTime,
                FlightNumber = model.FlightNumber,
                FreeBaggage = model.FreeBaggage,
                Layover = model.Layover,
                Rules = model.Rules,
                EquipmentType = new Equipment
                {
                    Code = model.EquipmentType.Code,
                    Name = model.EquipmentType.Name
                },
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
                    ArrivalPort = new Airport
                    {
                        City = new City
                        {
                            Code = model.Route.ArrivalPort.City.Code,
                            Name = model.Route.ArrivalPort.City.Name,
                            CountryCode = model.Route.ArrivalPort.City.CountryCode
                        },
                        Name = model.Route.ArrivalPort.Name,
                        Code = model.Route.ArrivalPort.Code
                    },
                    DeparturePort = new Airport
                    {
                        City = new City
                        {
                            Code = model.Route.DeparturePort.City.Code,
                            Name = model.Route.DeparturePort.City.Name,
                            CountryCode = model.Route.DeparturePort.City.CountryCode
                        },
                        Name = model.Route.DeparturePort.Name,
                        Code = model.Route.DeparturePort.Code
                    },

                }
            };
    }
}

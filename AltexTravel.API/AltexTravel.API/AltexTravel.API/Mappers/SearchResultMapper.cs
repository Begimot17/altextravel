using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Models.SearchResult;
using System.Collections.Generic;
using System.Linq;
using Domain = AltexTravel.API.Domain.RecomendationsModel;

namespace AltexTravel.API.Mappers
{
    public static class SearchResultMapper
    {
        public static List<RecommendationsViewModel> ToViewModel(this RecommendationQueryResponce model) =>
            model.FullRecommendations.Select(x => x?.ToViewModel()).ToList();

        public static RecommendationsViewModel ToViewModel(this Domain::FullRecommendations model) =>
            new RecommendationsViewModel
            {
                Recommendations = model.Recommendation.Select(x=>x?.ToViewModel()).ToList()
            };

        public static Recommendation ToViewModel(this Domain::Recommendation model) =>
            new Recommendation
            {
                CachedFlightReference = model.CachedFlightReference,
                PriceDetails = new PriceInfo
                {
                    DataSource = model.PriceDetails.DataSource,
                    PriceByPassengerType = new PriceByPassengerType
                    {
                        Adult = model.PriceDetails.PriceByPassengerType.Adult != null ? new PriceDetails
                        {
                            BaseFare = model.PriceDetails.PriceByPassengerType.Adult.BaseFare,
                            NumberOfPassengers = model.PriceDetails.PriceByPassengerType.Adult.NumberOfPassengers,
                            Total = model.PriceDetails.PriceByPassengerType.Adult.Total,
                            Taxes = model.PriceDetails.PriceByPassengerType.Adult.Taxes,
                            Fees = model.PriceDetails.PriceByPassengerType.Adult.Fees,
                        } : null,
                        Child = model.PriceDetails.PriceByPassengerType.Child!=null? new PriceDetails
                        {
                            BaseFare = model.PriceDetails.PriceByPassengerType.Child.BaseFare,
                            NumberOfPassengers = model.PriceDetails.PriceByPassengerType.Child.NumberOfPassengers,
                            Total = model.PriceDetails.PriceByPassengerType.Child.Total,
                            Taxes = model.PriceDetails.PriceByPassengerType.Child.Taxes,
                            Fees = model.PriceDetails.PriceByPassengerType.Child.Fees,
                        }:null,
                        Infant = model.PriceDetails.PriceByPassengerType.Infant != null ? new PriceDetails
                        {
                            BaseFare = model.PriceDetails.PriceByPassengerType.Infant.BaseFare,
                            NumberOfPassengers = model.PriceDetails.PriceByPassengerType.Infant.NumberOfPassengers,
                            Total = model.PriceDetails.PriceByPassengerType.Infant.Total,
                            Taxes = model.PriceDetails.PriceByPassengerType.Infant.Taxes,
                            Fees = model.PriceDetails.PriceByPassengerType.Infant.Fees,
                        } : null
                    },
                    Total = model.PriceDetails.Total
                },
                Segments = model.Segments?.ToViewModel()
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
                    Name = model.MarketingCarrier.Code
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

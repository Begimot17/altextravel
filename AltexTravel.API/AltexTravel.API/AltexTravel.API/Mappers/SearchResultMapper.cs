using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Domain.RecomendationsModel;
using AltexTravel.API.Models.SearchResult;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.Mappers
{
    public static class SearchResultMapper
    {
        public static List<RecommendationsViewModel> ToViewModel(this RecommendationQueryResponce model) =>
            model.FullRecommendations.Select(x => x?.ToViewModel()).ToList();

        public static RecommendationsViewModel ToViewModel(this FullRecommendations model) =>
            new RecommendationsViewModel
            {
                Recommendations = model.Recommendations.Select(x => x?.ToViewModel()).ToList()
            };

        public static Models.SearchResult.Recommendation ToViewModel(this Domain.RecomendationsModel.Recommendation model) =>
            new Models.SearchResult.Recommendation
            {
                CachedFlightReference = model.CachedFlightReference,
                PriceDetails = new Models.SearchResult.PriceInfo
                {
                    DataSource = model.PriceDetails.DataSource,
                    PriceByPassengerType = new Models.SearchResult.PriceByPassengerType
                    {
                        Adult = new Models.SearchResult.PriceDetails
                        {
                            BaseFare = model.PriceDetails.PriceByPassengerType.Adult.BaseFare,
                            NumberOfPassengers = model.PriceDetails.PriceByPassengerType.Adult.NumberOfPassengers,
                            Total = model.PriceDetails.PriceByPassengerType.Adult.Total,
                            Taxes = model.PriceDetails.PriceByPassengerType.Adult.Taxes,
                            Fees = model.PriceDetails.PriceByPassengerType.Adult.Fees,
                        },
                        Child = new Models.SearchResult.PriceDetails
                        {
                            BaseFare = model.PriceDetails.PriceByPassengerType.Child.BaseFare,
                            NumberOfPassengers = model.PriceDetails.PriceByPassengerType.Child.NumberOfPassengers,
                            Total = model.PriceDetails.PriceByPassengerType.Child.Total,
                            Taxes = model.PriceDetails.PriceByPassengerType.Child.Taxes,
                            Fees = model.PriceDetails.PriceByPassengerType.Child.Fees,
                        },
                        Infant = new Models.SearchResult.PriceDetails
                        {
                            BaseFare = model.PriceDetails.PriceByPassengerType.Infant.BaseFare,
                            NumberOfPassengers = model.PriceDetails.PriceByPassengerType.Infant.NumberOfPassengers,
                            Total = model.PriceDetails.PriceByPassengerType.Infant.Total,
                            Taxes = model.PriceDetails.PriceByPassengerType.Infant.Taxes,
                            Fees = model.PriceDetails.PriceByPassengerType.Infant.Fees,
                        }
                    },
                    Total = model.PriceDetails.Total
                },
                Segments = model.Segments?.ToViewModel()
            };
        public static List<Models.SearchResult.Segment> ToViewModel(this List<Domain.RecomendationsModel.Segment> model) =>
            model.Select(x => x?.ToViewModel()).ToList();

        public static Models.SearchResult.Segment ToViewModel(this Domain.RecomendationsModel.Segment model) =>
            new Models.SearchResult.Segment
            {
                Flights = model.Flights.Select(x => x?.ToViewModel()).ToList()
            };

        public static Models.SearchResult.Flight ToViewModel(this Domain.RecomendationsModel.Flight model) =>
            new Models.SearchResult.Flight
            {
                ElapseFlyingTime=model.ElapseFlyingTime,
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
                MarketingCarrier = new Models.SearchResult.Airline
                {
                    Code = model.MarketingCarrier.Code,
                    Name = model.MarketingCarrier.Code
                },
                OperatingCarrier = new Models.SearchResult.Airline
                {
                    Code = model.OperatingCarrier.Code,
                    Name = model.OperatingCarrier.Name
                },
                Route = new Models.SearchResult.AirportPair
                {
                    ArrivalPort = new Models.SearchResult.Airport
                    {
                        City = new Models.SearchResult.City
                        {
                            Code = model.Route.ArrivalPort.City.Code,
                            Name = model.Route.ArrivalPort.City.Name,
                            CountryCode = model.Route.ArrivalPort.City.CountryCode
                        },
                        Name = model.Route.ArrivalPort.Name,
                        Code = model.Route.ArrivalPort.Code
                    },
                    DeparturePort = new Models.SearchResult.Airport
                    {
                        City = new Models.SearchResult.City
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

using AltexTravel.API.Amadeus.Models.SearchResult;
using AltexTravel.API.Domain.RecomendationsModel;
using System;
using System.Linq;
namespace AltexTravel.API.DAL.Queries.Features.Recommendations
{
    public static class SearchResultMapper
    {
        public static RecommendationQueryResponce ToDomain(this SearchResult model) =>
            new RecommendationQueryResponce
            {
                FullRecommendations =model.Data.Select(x => x?.ToDomain()).ToList() 
            };

        public static FullRecommendations ToDomain(this Data model) =>
            new FullRecommendations
            {
                Recommendations = model.OfferItems.Select(x => x?.ToDomain()).ToList()
            };

        public static Recommendation ToDomain(this OfferItems model) =>
            new Recommendation
            {
                Segments = model.Services.Select(x => x?.ToDomain()).ToList(),
                CachedFlightReference="TODO",
                PriceDetails = new PriceInfo
                {
                    DataSource = "TODO",
                    PriceByPassengerType = new PriceByPassengerType
                    {
                        Adult = new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = 228,
                            Total = 228,
                            Taxes = 228,
                            Fees = new System.Collections.Generic.List<decimal> {
                                228
                            },
                        },
                        Child = new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = 228,
                            Total = 228,
                            Taxes = 228,
                            Fees = new System.Collections.Generic.List<decimal> {
                                228
                            },
                        },
                        Infant = new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = 228,
                            Total = 228,
                            Taxes = 228,
                            Fees = new System.Collections.Generic.List<decimal> {
                                228
                            },
                        }
                    },
                    Total = model.Price.Total
                },
            };

        public static Domain.RecomendationsModel.Segment ToDomain(this Services model) =>
            new Domain.RecomendationsModel.Segment
            {
                ElapseFlyingTime="TODO",
                Flights = model.Segments.Select(x => x?.ToDomain()).ToList(),
            };

        public static Flight ToDomain(this Amadeus.Models.SearchResult.Segment model)
        {
            //var airportArrival = LocationsFromDb.GetLocations(model.FlightSegment.Arrival.IataCode);
            //var airportDeparture = LocationsFromDb.GetLocations(model.FlightSegment.Departure.IataCode);

            return new Flight
            {
                EquipmentType= new EquipmentType
                {
                    Code="TODO",
                    Name= "TODO"
                },
                FreeBaggage="TODO",
                Layover="TODO",
                Rules="TODO",
                
                ArrivalTime = model.FlightSegment.Arrival.At,
                DepartureTime = model.FlightSegment.Departure.At,
                Cabin = model.PricingDetailPerAdult.TravelClass,
                FareBasis = model.PricingDetailPerAdult.FareClass,
                FlightNumber = model.FlightSegment.Number,
                FlyingTime = DifferenceTime(model.FlightSegment.Departure.At, model.FlightSegment.Arrival.At),
                MarketingCarrier = new Airline
                {
                    Code = model.FlightSegment.CarrierCode,
                    Name= "TODO"

                },
                OperatingCarrier = new Airline
                {
                    Code = model.FlightSegment.Operating.CarrierCode,
                    Name= "TODO"
                },
                Route = new AirportPair
                {
                    ArrivalPort = new Airport
                    {
                        City = new City
                        {
                            Code = model.FlightSegment.Arrival.IataCode,
                            CountryCode = model.FlightSegment.CarrierCode,
                            Name = "TODO"
                        },
                        Code = "TODO",
                        Name = "TODO"
                    },
                    DeparturePort = new Airport
                    {
                        City = new City
                        {
                            Code = model.FlightSegment.Departure.IataCode,
                            CountryCode = model.FlightSegment.CarrierCode,
                            Name= "TODO"

                        },
                        Code= "TODO",
                        Name= "TODO"
                    },

                }
            };
        }
        public static TimeSpan DifferenceTime(string firstTime, string lastTime)
        {
            var firstDate = DateTime.Parse(firstTime);
            var lastDate = DateTime.Parse(lastTime);
            var difference = lastDate - firstDate;
            return difference;
        }
    }
}

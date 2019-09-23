using Amadeus = AltexTravel.API.Amadeus.Models.SearchResult;
using AltexTravel.API.DAL.Features.SearchResult;
using System;
using System.Collections.Generic;
using System.Linq;
using AltexTravel.API.Domain.RecomendationsModel;

namespace AltexTravel.API.DAL.Queries.Features.Recommendations
{
    public static class SearchResultMapper
    {
        public static RecommendationQueryResponce ToDomain(this Amadeus::AmadeusSearchResult model) =>
            new RecommendationQueryResponce
            {
                FullRecommendations = model.Data.Select(x => x?.ToDomain()).ToList()
            };

        public static FullRecommendations ToDomain(this Amadeus::Data model) =>
            new FullRecommendations
            {
                Recommendations = model.OfferItems.Select(x => x?.ToDomain()).ToList()
            };

        public static Recommendation ToDomain(this Amadeus::OfferItems model) =>
            new Recommendation
            {
                Segments = model.Services.Select(x => x?.ToDomain()).ToList(),
                CachedFlightReference = "TODO",
                PriceDetails = new PriceInfo
                {
                    DataSource = "TODO",
                    PriceByPassengerType = new PriceByPassengerType
                    {
                        Adult = new PriceDetails
                        {
                            BaseFare = 28,
                            NumberOfPassengers = 228,
                            Total = (decimal)model.PricePerAdult.Total,
                            Taxes = (decimal)model.PricePerAdult.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            },
                        },
                        Child = new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = 228,
                            Total = (decimal)model.PricePerChild.Total,
                            Taxes = (decimal)model.PricePerChild.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            },
                        },
                        Infant = new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = 228,
                            Total = (decimal)model.PricePerInfant.Total,
                            Taxes = (decimal)model.PricePerInfant.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            },
                        }
                    },
                    Total = model.Price.Total
                },
            };

        public static Segment ToDomain(this Amadeus::Services model) =>
            new Segment
            {
                Flights = model.Segments.Select(x => x?.ToDomain()).ToList(),
            };

        public static Flight ToDomain(this Amadeus::Segment model)
        {
            return new Flight
            {
                ElapseFlyingTime = model.FlightSegment.Duration,
                EquipmentType = new EquipmentType
                {
                    Code = model.FlightSegment.Aircraft.Code,
                    Name = "TODO"
                },
                FreeBaggage = null,
                Layover = null,
                Rules = null,

                ArrivalTime = model.FlightSegment.Arrival.At,
                DepartureTime = model.FlightSegment.Departure.At,
                Cabin = model.PricingDetailPerAdult.TravelClass,
                FareBasis = model.PricingDetailPerAdult.FareClass,
                FlightNumber = model.FlightSegment.Number,
                FlyingTime = DifferenceTime(model.FlightSegment.Departure.At, model.FlightSegment.Arrival.At),
                MarketingCarrier = new Airline
                {
                    Code = model.FlightSegment.CarrierCode,
                    Name = "TODO"

                },
                OperatingCarrier = new Airline
                {
                    Code = model.FlightSegment.Operating.CarrierCode,
                    Name = "TODO"
                },
                Route = new AirportPair
                {
                    ArrivalPort = new Airport
                    {
                        City = new City
                        {
                            Code = model.FlightSegment.Arrival.IataCode,
                            CountryCode = model.FlightSegment.CarrierCode,
                            //Name = LocationsFromDb.GetLocations(model.FlightSegment.Arrival.IataCode).Country
                            Name = "TODO"
                        },
                        // Code = LocationsFromDb.GetLocations(model.FlightSegment.Arrival.IataCode).Code,
                        Code = "TODO",
                        //Name = LocationsFromDb.GetLocations(model.FlightSegment.Arrival.IataCode).Name
                        Name = "TODO"
                    },
                    DeparturePort = new Airport
                    {
                        City = new City
                        {
                            Code = model.FlightSegment.Departure.IataCode,
                            CountryCode = model.FlightSegment.CarrierCode,
                            //Name= LocationsFromDb.GetLocations(model.FlightSegment.Departure.IataCode).Country
                            Name = "TODO"

                        },
                        // Code = LocationsFromDb.GetLocations(model.FlightSegment.Departure.IataCode).Code,
                        Code = "TODO",
                        //Name = LocationsFromDb.GetLocations(model.FlightSegment.Departure.IataCode).Name
                        Name = "TODO"
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

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
                FullRecommendations = model.Data.SelectMany(x => x.OfferItems.ToList().Select(y=>y?.ToDomain())).ToList()
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
                        Adult = model.PricePerAdult != null ? new PriceDetails
                        {
                            BaseFare = 28,
                            NumberOfPassengers = 228,
                            Total = (decimal)model.PricePerAdult.Total,
                            Taxes = (decimal)model.PricePerAdult.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            },
                        } : null,
                        Child = model.PricePerChild != null ? new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = 228,
                            Total = (decimal)model.PricePerChild.Total,
                            Taxes = (decimal)model.PricePerChild.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            },
                        } : null,
                        Infant = model.PricePerInfant!=null? new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = 228,
                            Total = (decimal)model.PricePerInfant.Total,
                            Taxes = (decimal)model.PricePerInfant.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            },
                        }:null
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
                EquipmentType = new EquipmentType
                {
                    Code = model.FlightSegment.Aircraft.Code,
                    Name = "TODO"
                },
                FreeBaggage = null,
                Layover = null,
                Rules = null,

                ElapseFlyingTime = model.FlightSegment.Duration.FlyingTimeConvert(),

                ArrivalTime = model.FlightSegment.Arrival.At,
                DepartureTime = model.FlightSegment.Departure.At,
                Cabin = model.PricingDetailPerAdult.TravelClass,
                FareBasis = model.PricingDetailPerAdult.FareBasis,
                FlightNumber = model.FlightSegment.Number,
                FlyingTime = ConvertDataTime.DifferenceTime(model.FlightSegment.Departure.At, model.FlightSegment.Arrival.At),
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

    }
}

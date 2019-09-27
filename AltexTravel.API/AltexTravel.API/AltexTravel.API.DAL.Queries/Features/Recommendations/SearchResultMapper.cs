using AltexTravel.API.Amadeus.Models.SearchResult;
using AltexTravel.API.DAL.Features.SearchResult;
using AltexTravel.API.Domain.RecomendationsModel;
using System.Collections.Generic;
using System.Linq;
using Amadeus = AltexTravel.API.Amadeus.Models.SearchResult;
using Domain = AltexTravel.API.Domain.RecomendationsModel;

namespace AltexTravel.API.DAL.Queries.Features.Recommendations
{
    public static class SearchResultMapper
    {
        public static RecommendationQuery Request { get; set; }
        public static Dictionaries Dictionaries { get; set; }

        public static RecommendationQueryResponce ToDomain(this AmadeusSearchResult model, RecommendationQuery request)
        {
            Request = request;
            Dictionaries = model.Dictionaries;
            return new RecommendationQueryResponce
            {
                FullRecommendations = model.Data.SelectMany(x => x?.OfferItems.ToList().Select(y => y?.ToDomain())).ToList()
            };
        }

        public static Recommendation ToDomain(this OfferItems model) =>
            new Recommendation
            {
                Segments = model.Services.Select(x => x?.ToDomain()).ToList(),
                CachedFlightReference = "TODO",
                PriceDetails = new List<PriceInfo> {
                new PriceInfo
                {
                    DataSource = "Amadeus",
                    PriceByPassengerType = new PriceByPassengerType
                    {
                        Adult = Request.NumberOfAdults != 0 ? new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = Request.NumberOfAdults,
                            Total = model.PricePerAdult.Total,
                            Taxes = model.PricePerAdult.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            }
                        } : null,
                        Child = Request.NumberOfChildren != 0 ? new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = Request.NumberOfChildren,
                            Total = model.PricePerChild.Total,
                            Taxes = model.PricePerChild.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            }
                        } : null,
                        Infant = Request.NumberOfInfants != 0 ? new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = Request.NumberOfInfants,
                            Total = model.PricePerInfant.Total,
                            Taxes = model.PricePerInfant.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            }
                        } : null
                    },
                    Total = model.Price.Total}
                },
            };

        public static Domain::Segment ToDomain(this Services model) =>
            new Domain::Segment
            {
                ElapseFlyingTime = model.FlyingTimeConvert(),
                Flights = model.Segments.Select(x => x?.ToDomain()).ToList(),
            };

        public static Flight ToDomain(this Amadeus::Segment model)
        {
            return new Flight
            {
                EquipmentType = new EquipmentType
                {
                    Code = model.FlightSegment.Aircraft.Code,
                    Name = Dictionaries.Aircraft.First(x => x.Key == model.FlightSegment.Aircraft.Code).Value
                },
                FreeBaggage = null,
                Layover = null,
                Rules = null,
                ArrivalTime = model.FlightSegment.Arrival.At,
                DepartureTime = model.FlightSegment.Departure.At,
                Cabin = model.PricingDetailPerAdult.TravelClass,
                FareBasis = model.PricingDetailPerAdult.FareBasis,
                FlightNumber = model.FlightSegment.Number,
                FlyingTime = ConvertDataTime.DifferenceTime(model.FlightSegment.Departure.At, model.FlightSegment.Arrival.At),
                MarketingCarrier = new Airline
                {
                    Code = model.FlightSegment.CarrierCode,
                    Name = Dictionaries.Carriers.First(x => x.Key == model.FlightSegment.CarrierCode).Value

                },
                OperatingCarrier = new Airline
                {
                    Code = model.FlightSegment.Operating.CarrierCode
                    ?? Dictionaries.Carriers.First(x => x.Key == model.FlightSegment.CarrierCode).Key,
                    Name = Dictionaries.Carriers.FirstOrDefault(x => x.Key == model.FlightSegment.Operating.CarrierCode).Value
                    ?? Dictionaries.Carriers.First(x => x.Key == model.FlightSegment.CarrierCode).Value
                },
                Route = new AirportPair
                {
                    ArrivalPort = new Airport
                    {
                        Code = model.FlightSegment.Arrival.IataCode,
                    },
                    DeparturePort = new Airport
                    {
                        Code = model.FlightSegment.Departure.IataCode,
                    },

                }
            };
        }
    }
}

using AltexTravel.API.Amadeus.Models.SearchResult;
using AltexTravel.API.DAL.Features.SearchResult;
using AltexTravel.API.Domain.RecomendationsModel;
using System.Collections.Generic;
using System.Linq;
using Amadeus = AltexTravel.API.Amadeus.Models.SearchResult;
using Segment = AltexTravel.API.Domain.RecomendationsModel.Segment;

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
                            Total = (decimal)model.PricePerAdult.Total,
                            Taxes = (decimal)model.PricePerAdult.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            }
                        } : new PriceDetails{ },
                        Child = Request.NumberOfChildren != 0 ? new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = Request.NumberOfChildren,
                            Total = (decimal)model.PricePerChild.Total,
                            Taxes = (decimal)model.PricePerChild.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            }
                        } : new PriceDetails{ },
                        Infant = Request.NumberOfInfants != 0 ? new PriceDetails
                        {
                            BaseFare = 228,
                            NumberOfPassengers = Request.NumberOfInfants,
                            Total = (decimal)model.PricePerInfant.Total,
                            Taxes = (decimal)model.PricePerInfant.TotalTaxes,
                            Fees = new List<decimal> {
                                228
                            }
                        } : new PriceDetails{ }
                    },
                    Total = model.Price.Total}
                },
            };

        public static Segment ToDomain(this Services model) =>
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
                    Name = Dictionaries.Aircraft.First(x => x.Key == model.FlightSegment.Aircraft.Code).Value
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
                    Name = Dictionaries.Carriers.First(x => x.Key == model.FlightSegment.CarrierCode).Value

                },
                OperatingCarrier = new Airline
                {
                    Code = model.FlightSegment.Operating.CarrierCode,
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

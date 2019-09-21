using AltexTravel.API.Models.SearchResult;
using System;
using System.Collections.Generic;

namespace AltexTravel.API
{
    public class DefaultSearchResult
    {
        public static RecommendationsViewModel RecommendationQuery() =>
            new RecommendationsViewModel
            {
                Recommendations = new List<Recommendation> {
            new Recommendation
            {
                CachedFlightReference = "CachedFlightReference",
                PriceDetails = new PriceInfo
                {
                    DataSource = "DataSource",
                    PriceByPassengerType = new PriceByPassengerType
                    {
                        Adult = new PriceDetails
                        {
                            BaseFare = 0,
                            Fees = new List<decimal>
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        },
                        Child = new PriceDetails
                        {
                            BaseFare = 0,
                            Fees = new List<decimal>
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        },
                        Infant = new PriceDetails
                        {
                            BaseFare = 0,
                            Fees =new List<decimal>
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        }
                     }
                },
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        ElapseFlyingTime="ElapseFlyingTime",
                        Flights=new List<Flight>
                        {
                            new Flight
                            {
                                ArrivalTime=" time",
                                Cabin="Cabin",
                                MarketingCarrier=new Airline
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                EquipmentType=new Equipment
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                FareBasis="FareBasis",
                                FlightNumber=123,
                                FlyingTime=new TimeSpan(3,2,1),
                                FreeBaggage="FreeBaggage",
                                Layover="Layover",
                                OperatingCarrier=new Airline
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                Route=new AirportPair
                                {
                                    ArrivalPort=new Airport
                                    {
                                        City=new City
                                        {
                                            Code="Code",
                                            CountryCode="CountryCode",
                                            Name="Name"
                                        },
                                        Code="Code",
                                        Name="Name"

                                    },
                                    DeparturePort=new Airport
                                    {
                                        City=new City
                                        {
                                            Code="Code",
                                            CountryCode="CountryCode",
                                            Name="Name"
                                        },
                                        Code="Code",
                                        Name="Name"

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
            };

    }
}




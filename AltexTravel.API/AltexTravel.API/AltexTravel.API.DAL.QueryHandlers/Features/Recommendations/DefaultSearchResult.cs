using AltexTravel.API.DAL.Queries.Features.Recommendations;
using System;
using System.Collections.Generic;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public class DefaultSearchResult
    {
        public static RecommendationQueryResponce GetDefaultSearch()
        {
            return new RecommendationQueryResponce
            {
                Recommendations = new List<Domain.Reccomendations.Recommendation>
                {
            new Domain.Reccomendations.Recommendation
            {
                CachedFlightReference = "CachedFlightReference",
                PriceDetails = new Domain.Reccomendations.PriceInfo
                {
                    DataSource = "DataSource",
                    PriceByPassengerType = new Domain.Reccomendations.PriceByPassengerType
                    {
                        Adult = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        },
                        Child = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        },
                        Infant = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        }
                     }
                },
                Segments = new List<Domain.Reccomendations.Segment>
                {
                    new Domain.Reccomendations.Segment
                    {
                        ElapseFlyingTime="ElapseFlyingTime",
                        Flights=new List<Domain.Reccomendations.Flight>
                        {
                            new Domain.Reccomendations.Flight
                            {
                                ArrivalTime=DateTime.Now,
                                Cabin=Domain.Reccomendations.Cabins.Economy,
                                MarketingCarrier=new Domain.Reccomendations.Airline
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                EquipmentType=new Domain.Reccomendations.EquipmentType
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                FareBasis="FareBasis",
                                FlightNumber="FlightNumber",
                                FlyingTime="FlyingTime",
                                FreeBaggage="FreeBaggage",
                                Layover="Layover",
                                OperatingCarrier=new Domain.Reccomendations.Airline
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                Route=new Domain.Reccomendations.AirportPair
                                {
                                    ArrivalPort=new Domain.Reccomendations.Airport
                                    {
                                        City=new Domain.Reccomendations.City
                                        {
                                            Code="Code",
                                            CountryCode="CountryCode",
                                            Name="Name"
                                        },
                                        Code="Code",
                                        Name="Name"

                                    },
                                    DeparturePort=new Domain.Reccomendations.Airport
                                    {
                                        City=new Domain.Reccomendations.City
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
            },
            new Domain.Reccomendations.Recommendation
            {
                CachedFlightReference = "CachedFlightReference",
                PriceDetails = new Domain.Reccomendations.PriceInfo
                {
                    DataSource = "DataSource",
                    PriceByPassengerType = new Domain.Reccomendations.PriceByPassengerType
                    {
                        Adult = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        },
                        Child = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        },
                        Infant = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        }
                     }
                },
                Segments = new List<Domain.Reccomendations.Segment>
                {
                    new Domain.Reccomendations.Segment
                    {
                        ElapseFlyingTime="ElapseFlyingTime",
                        Flights=new List<Domain.Reccomendations.Flight>
                        {
                            new Domain.Reccomendations.Flight
                            {
                                ArrivalTime=DateTime.Now,
                                Cabin=Domain.Reccomendations.Cabins.Economy,
                                MarketingCarrier=new Domain.Reccomendations.Airline
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                EquipmentType=new Domain.Reccomendations.EquipmentType
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                FareBasis="FareBasis",
                                FlightNumber="FlightNumber",
                                FlyingTime="FlyingTime",
                                FreeBaggage="FreeBaggage",
                                Layover="Layover",
                                OperatingCarrier=new Domain.Reccomendations.Airline
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                Route=new Domain.Reccomendations.AirportPair
                                {
                                    ArrivalPort=new Domain.Reccomendations.Airport
                                    {
                                        City=new Domain.Reccomendations.City
                                        {
                                            Code="Code",
                                            CountryCode="CountryCode",
                                            Name="Name"
                                        },
                                        Code="Code",
                                        Name="Name"

                                    },
                                    DeparturePort=new Domain.Reccomendations.Airport
                                    {
                                        City=new Domain.Reccomendations.City
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
            },
            new Domain.Reccomendations.Recommendation
            {
                CachedFlightReference = "CachedFlightReference",
                PriceDetails = new Domain.Reccomendations.PriceInfo
                {
                    DataSource = "DataSource",
                    PriceByPassengerType = new Domain.Reccomendations.PriceByPassengerType
                    {
                        Adult = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        },
                        Child = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        },
                        Infant = new Domain.Reccomendations.PriceDetails
                        {
                            BaseFare = 0,
                            Fees =
                            {
                                0,0,0
                            },
                            NumberOfPassengers = 0,
                            Taxes = 0,
                        }
                     }
                },
                Segments = new List<Domain.Reccomendations.Segment>
                {
                    new Domain.Reccomendations.Segment
                    {
                        ElapseFlyingTime="ElapseFlyingTime",
                        Flights=new List<Domain.Reccomendations.Flight>
                        {
                            new Domain.Reccomendations.Flight
                            {
                                ArrivalTime=DateTime.Now,
                                Cabin=Domain.Reccomendations.Cabins.Economy,
                                MarketingCarrier=new Domain.Reccomendations.Airline
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                EquipmentType=new Domain.Reccomendations.EquipmentType
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                FareBasis="FareBasis",
                                FlightNumber="FlightNumber",
                                FlyingTime="FlyingTime",
                                FreeBaggage="FreeBaggage",
                                Layover="Layover",
                                OperatingCarrier=new Domain.Reccomendations.Airline
                                {
                                    Code="Code",
                                    Name="Name"
                                },
                                Route=new Domain.Reccomendations.AirportPair
                                {
                                    ArrivalPort=new Domain.Reccomendations.Airport
                                    {
                                        City=new Domain.Reccomendations.City
                                        {
                                            Code="Code",
                                            CountryCode="CountryCode",
                                            Name="Name"
                                        },
                                        Code="Code",
                                        Name="Name"

                                    },
                                    DeparturePort=new Domain.Reccomendations.Airport
                                    {
                                        City=new Domain.Reccomendations.City
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
                    } }
        }
                }
            };
        }
    }
}




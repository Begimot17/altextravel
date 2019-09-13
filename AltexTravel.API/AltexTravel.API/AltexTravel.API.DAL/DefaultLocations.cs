using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using System.Collections.Generic;

namespace AltexTravel.API.DAL
{
    public static class DefaultLocations
    {
        public static Location Locations { get; set; }
        public static List<Location> GetLocations() => new List<Location>
            {
                new Location
                {
                    Airports=new List<IataCode>
                    {
                        new IataCode
                        {
                            Code="DefaultCode",
                            Name="DefaultName"
                        },
                        new IataCode
                        {
                            Code="Code",
                            Name="Name"
                        }
                    },
                    Code="CodeLoc",
                    Name="NameLoc",
                    Type="TypeLoc"
                },

                new Location
                {
                    Airports=new List<IataCode>
                    {
                        new IataCode
                        {
                            Code="CodeDefault",
                            Name="Code"
                        },
                        new IataCode
                        {
                            Code="CodeIata",
                            Name="Code"
                        }
                    },
                    Code="LocCodeDefault",
                    Name="LocNameDefault",
                    Type="LocTypeDefault"
                },
            };
    }
}


using AltexTravel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API
{
    public static class DefaultLocations
    {
        public static LocationViewModel Locations { get; set; }
        public static List<LocationViewModel> GetLocations()
        {
            var locations = new List<LocationViewModel>
            {
                new LocationViewModel
                {
                    Airports=new List<IataCodeViewModel>
                    {
                        new IataCodeViewModel
                        {
                            Name="DefaultIataAirport",
                            Code="DefaultIataCode"
                        },
                        new IataCodeViewModel
                        {
                            Name="DefIataAirport",
                            Code="DefIataCode"
                        }
                    },
                    Name="DefaultLocation",
                    Code="DefaultCode",
                    Type="DefaultType"
                },
                new LocationViewModel
                {
                    Airports=new List<IataCodeViewModel>
                    {
                        new IataCodeViewModel
                        {
                            Name="Name",
                            Code="Code"
                        },
                        new IataCodeViewModel
                        {
                            Name="name",
                            Code="code"
                        }
                    },
                    Name="Name",
                    Code="Code",
                    Type="Type"
                },

            };
            return locations;
        }
    }
}

using AltexTravel.API.DAL.Features.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.Amadeus.Amadeus
{
    public class LocationsModel
    {
        public IEnumerable<Location> Locations { get; set; }
    }
}

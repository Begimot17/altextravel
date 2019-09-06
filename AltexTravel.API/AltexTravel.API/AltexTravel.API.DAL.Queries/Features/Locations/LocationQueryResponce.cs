using AltexTravel.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL.Queries.Features.Locations
{
    public class LocationQueryResponce
    {
        public IEnumerable<Location> Locations { get; set; }
    }
}

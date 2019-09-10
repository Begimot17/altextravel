using AltexTravel.API.Domain;
using System.Collections.Generic;

namespace AltexTravel.API.DAL.Queries.Features.Locations
{
    public class LocationQueryResponce
    {
        public IEnumerable<Location> Locations { get; set; }
    }
}

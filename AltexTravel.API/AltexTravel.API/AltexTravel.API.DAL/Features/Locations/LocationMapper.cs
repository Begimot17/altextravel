using AltexTravel.API.Amadeus.Models;
using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.Amadeus
{
    public static class LocationMapper
    {
        public static List<IataCode> ToIataCode(this IEnumerable<IataCodeDal> locations)
        {
            return locations.Select(x => x.ToIataCode()).ToList();
        }
        public static List<Location> ToLocations(this IEnumerable<LocationDal> locations)
        {
            return locations.Select(x => x.ToLocation()).ToList();
        }
        
        
        public static IataCode ToIataCode(this IataCodeDal model)
        {
            if (model != null)
            {
                return new IataCode
                {
                    Name = model.Name,
                    Code = model.Code
                };
            }
            return new IataCode();
        }
        public static Location ToLocation(this LocationDal model)
        {
            if (model.Airports != null)
            {
                return new Location
                {
                    Name = model.Name,
                    Code = model.Code,
                    Type = model.Type,
                    Airports = model.Airports.ToIataCode()
                };
            }
            return new Location
            {
                Name = model.Name,
                Code = model.Code,
                Type = model.Type,
                Airports = null
            };
        }

    }
}

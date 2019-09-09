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
            return (model != null) ?
               new IataCode
               {
                   Name = model.Name,
                   Code = model.Code,
               } :
           new IataCode();
        }
        public static Location ToLocation(this LocationDal model)
        {
            return (model.Airports != null) ?
                new Location
                {
                    Name = model.Name,
                    Code = model.Code,
                    Type = model.Type,
                    Airports = model.Airports.ToIataCode()
                } :
            new Location
            {
                Name = model.Name,
                Code = model.Code,
                Type = model.Type,
                Airports = null
            };
        }

    }
}

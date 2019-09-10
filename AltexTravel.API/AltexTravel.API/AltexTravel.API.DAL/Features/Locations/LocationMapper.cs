using AltexTravel.API.Amadeus.Models;
using AltexTravel.API.DAL.Features.IataCodes;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.DAL.Features.Locations
{
    public static class LocationMapper
    {
        public static List<IataCode> ToIata(this List<IataAmadeus> locations) =>
            locations.Select(x => x.ToIata()).ToList();

        public static IEnumerable<Location> ToLocation(this IEnumerable<LocationAmadeus> locations) =>
            locations.Select(x => x.ToLocation()).ToList();

        public static IataCode ToIata(this IataAmadeus model)
        {
            return (model != null) ?
               new IataCode
               {
                   Name = model.Name,
                   Code = model.Code,
               } :
           new IataCode();
        }
        public static Location ToLocation(this LocationAmadeus model) => new Location
        {
            Name = model.Name,
            Code = model.Code,
            Type = model.Type,
            Airports = model.Airports?.ToIata()
        };


    }
}

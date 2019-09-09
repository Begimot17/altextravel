using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.DAL.Amadeus
{
    public static class AmadeusMapper
    {
        public static List<IataCode> ToIataCode(this IEnumerable<IataAmadeus> locations)
        {
            return locations.Select(x => x.ToIataCode()).ToList();
        }
        public static List<Location> ToLocations(this IEnumerable<LocationAmadeus> locations)
        {
            return locations.Select(x => x.ToLocation()).ToList();
        }
        public static List<IataAmadeus> ToIataAmadeus(this IEnumerable<LocationAmadeus> locations)
        {
            return locations.Select(x => x.ToIataAmadeus()).ToList();
        }
        public static IataAmadeus ToIataAmadeus(this LocationAmadeus model)
        {
            if (model!=null)
            {
                return new IataAmadeus
                {
                    Name = model.Name,
                    Code = model.Code
                };
            }
            return new IataAmadeus();
        }
        public static IataCode ToIataCode(this IataAmadeus model)
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
        public static Location ToLocation(this LocationAmadeus model)
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

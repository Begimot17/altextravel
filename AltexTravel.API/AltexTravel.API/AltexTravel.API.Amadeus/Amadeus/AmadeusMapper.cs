using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.Amadeus.Amadeus
{
    public static class AmadeusMapper
    {
        public static List<IataAmadeus> ToIataAmadeus(this IEnumerable<LocationAmadeus> locations)
        {
            return locations.Select(x => x.ToIataAmadeus()).ToList();
        }
        public static IataAmadeus ToIataAmadeus(this LocationAmadeus model)
        {
            return new IataAmadeus
            {
                Name = model.Name,
                Code = model.Code
            };
        }
        public static LocationsModel ToLocations(this AmadeusModel model)
        {
            var locModel = new LocationsModel
            {
                Locations = model.Data.Select(x => x.ToLocations())
            };
            return locModel;
        }
        public static Location ToLocations(this LocationAmadeus model)
        {
            return new Location
            {
                Name = model.Name,
                Code = model.Code,
                Type = model.Type,
                Airports = model.Airports.ToIata()
            };
        }
        public static List<IataCode> ToIata(this IEnumerable<IataAmadeus> locations)
        {
            return locations.Select(x => x.ToIata()).ToList();
        }
        public static IataCode ToIata(this IataAmadeus model)
        {
            return new IataCode
            {
                Name = model.Name,
                Code = model.Code
            };
        }
    }
}

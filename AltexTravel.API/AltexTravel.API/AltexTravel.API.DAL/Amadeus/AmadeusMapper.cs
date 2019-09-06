using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.DAL.Amadeus
{
    public static class AmadeusMapper
    {
        public static List<IataAmadeus> ToIataAmadeus(this IEnumerable<LocationAmadeus> locations)
        {
            return locations.Select(x => x.ToIata()).ToList();
        }
        public static IataAmadeus ToIata(this LocationAmadeus model)
        {
            return new IataAmadeus
            {
                Name = model.Name,
                Code = model.Code
            };
        }
        public static LocationsModel ToLocations(this AmadeusModel model)
        {
            return model.Data.Select(x => x.ToLocations());
        }
        public static Location ToLocations(this LocationAmadeus model)
        {
            return new Location
            {
                Name=model.Name,Code=model.Code,Type=model.Type,Airports=new IataCode {Name=model.Airports.Name}
            };
        }
        public static List<IataAmadeus> ToIata(this IEnumerable<LocationAmadeus> locations)
        {
            return locations.Select(x => x.ToIata()).ToList();
        }
        public static IataAmadeus ToIata(this LocationAmadeus model)
        {
            return new IataAmadeus
            {
                Name = model.Name,
                Code = model.Code
            };
        }
    }
}

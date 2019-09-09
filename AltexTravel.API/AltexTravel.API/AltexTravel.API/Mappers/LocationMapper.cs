using AltexTravel.API.Amadeus.Models;
using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using AltexTravel.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.Mappers
{
    public static class LocationMapper
    {
        public static IEnumerable<LocationViewModel> ToViewModel(this IEnumerable<Domain.Location> models) =>
            models.Select(x => x.ToViewModel());

        public static LocationViewModel ToViewModel(this Domain.Location model) => new LocationViewModel
        {
            Name = model.Name,
            Code = model.Code,
            Type = model.Type,
            Airports = model.Airports?.ToViewModel()
        };

        public static List<IataCode> ToIatas(this List<IataAmadeus> locations) =>
            locations.Select(x => x.ToIata()).ToList();

        public static IEnumerable<Location> ToLocations(this List<LocationAmadeus> locations) =>
            locations.Select(x => x.ToLocation());

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
            Airports = model.Airports?.ToIatas()
        };

    }
}

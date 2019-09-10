using AltexTravel.API.DAL.Features.Locations;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.DAL.BaseHandlers.Mappers
{
    public static class LocationsMapper
    {
        public static IEnumerable<Domain.Location> ToDomain(this List<Location> models) =>
            models.Select(x => x.ToDomain());

        public static Domain.Location ToDomain(this Location model) => new Domain.Location
        {
            Name = model.Name,
            Code = model.Code,
            Type = model.Type,
            Airports = model.Airports?.ToDomain()
        };
    }
}

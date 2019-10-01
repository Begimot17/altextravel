using AltexTravel.API.DAL.Queries.Features.Locations;
using AltexTravel.API.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AltexTravel.API.Mappers
{
    public static class LocationMapper
    {
        public static IEnumerable<LocationViewModel> ToViewModel(this LocationQueryResponce model) =>
            model.Locations.Select(x => x.ToViewModel());

        public static LocationViewModel ToViewModel(this Domain.Location model) => new LocationViewModel
        {
            Name = model.Name.StringToTitleCase(),
            Code = model.Code,
            Type = model.Type,
            Country = model.Country.StringToTitleCase(),
            Airports = model.Airports?.ToViewModel()
        };
    }
}

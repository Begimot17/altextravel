﻿using AltexTravel.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.Mappers
{
    public static class LocationMapper
    {
        public static IEnumerable<LocationViewModel> ToViewModel(this IEnumerable<Domain.Location> models) =>
            models.Select(x => x?.ToViewModel());

        public static LocationViewModel ToViewModel(this Domain.Location model) => new LocationViewModel
        {
            Name = model.Name,
            Code = model.Code,
            Type = model.Type,
            Country=model.Country,
            Airports = model.Airports?.ToViewModel()
        };
    }
}

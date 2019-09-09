using AltexTravel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Mappers
{
    public static class LocationMapper
    {
        public static IEnumerable<LocationViewModel> ToViewModel(this IEnumerable<Domain.Location> models)
        {

            return models.Select(x => x.ToViewModel());
        }
        public static LocationViewModel ToViewModel(this Domain.Location model)
        {
            if (model.Airports!=null)
            {
                return new LocationViewModel
                {
                    Name = model.Name,
                    Code = model.Code,
                    Type = model.Type,
                    Airports = model.Airports.ToViewModel()
                };
            }
            return new LocationViewModel
            {
                Name = model.Name,
                Code = model.Code,
                Type = model.Type,
                Airports = null
            };
        }


    }
}

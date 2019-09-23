using AltexTravel.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.Mappers
{
    public static class IataMapper
    {
        public static IEnumerable<IataCodeViewModel> ToViewModel(this IEnumerable<Domain.IataCode> models) =>
            models.Select(x => x?.ToViewModel());

        public static IataCodeViewModel ToViewModel(this Domain.IataCode model) =>
              new IataCodeViewModel
              {
                  Name = model.Name,
                  Code = model.Code,
                  Country = model.Country
              };
    }
}


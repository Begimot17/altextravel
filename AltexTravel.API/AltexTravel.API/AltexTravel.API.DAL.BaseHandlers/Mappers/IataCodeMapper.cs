using AltexTravel.API.DAL.Features.IataCodes;
using System.Collections.Generic;
using System.Linq;

namespace AltexTravel.API.DAL.BaseHandlers.Mappers
{
    public static class IataCodeMapper
    {
        public static IEnumerable<Domain.IataCode> ToDomain(this List<IataCode> models) =>
            models.Select(x => x.ToDomain());

        public static Domain.IataCode ToDomain(this IataCode model) =>
            new Domain.IataCode
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code
            };

        public static IataCode ToDal(this Domain.IataCode model) =>
        new IataCode
        {
            Id = model.Id,
            Name = model.Name,
            Code = model.Code
        };
    }
}

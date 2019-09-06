using AltexTravel.API.DAL.Features.IataCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltexTravel.API.DAL.BaseHandlers.Mappers
{
    public static class IataCodeMapper
    {
        public static IEnumerable<Domain.IataCode> ToDomain(this List<IataCode> models)
        {

            return models.Select(x => x.ToDomain());
        }
        public static Domain.IataCode ToDomain(this IataCode model)
        {
            return new Domain.IataCode
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code
            };
        }
        public static IataCode ToDal(this Domain.IataCode model)
        {
            return new IataCode
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code
            };
        }
    }
}

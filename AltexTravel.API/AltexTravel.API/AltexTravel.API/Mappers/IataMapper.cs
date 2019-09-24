using AltexTravel.API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AltexTravel.API.Mappers
{
    public static class IataMapper
    {
        public static TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public static IEnumerable<IataCodeViewModel> ToViewModel(this IEnumerable<Domain.IataCode> models) =>
            models.Select(x => x?.ToViewModel());

        public static IataCodeViewModel ToViewModel(this Domain.IataCode model)
        {
            string x = textInfo.ToTitleCase(model.Name);
                return
            new IataCodeViewModel
            {
                Name = model.Name.StringToTitleCase(),
                Code = model.Code,
                Country = model.Country.StringToTitleCase()
            };
        }
        
    }
}


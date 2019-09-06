using AltexTravel.API.DAL.Commands.Features.Locations;
using AltexTravel.API.DAL.Queries.Features.Locations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AltexTravel.API.DAL.CommandHandlers.Features.Locations
{
    public class LocationValidator : AbstractValidator<LocationQuery>
    {
        public LocationValidator()
        {
            RuleFor(x => x.Count).GreaterThan(10);
            RuleFor(x => x.Search).NotEmpty();
        }
    }
}

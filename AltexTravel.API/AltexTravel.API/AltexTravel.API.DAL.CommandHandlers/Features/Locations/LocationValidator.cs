using AltexTravel.API.DAL.Queries.Features.Locations;
using FluentValidation;

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

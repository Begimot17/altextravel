using AltexTravel.API.DAL.Queries.Features.Recommendations;
using FluentValidation;
using System;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public class RecommendationValidator : AbstractValidator<RecommendationQuery>
    {
        public RecommendationValidator()
        {
            RuleFor(x => x.ArrivalPort).NotEmpty();
            RuleFor(x => x.Cabin).NotEmpty();
            RuleFor(x => x.DemandDirectFlight).NotEmpty();
            RuleFor(x => x.ReturnDate).NotEmpty().GreaterThanOrEqualTo(x=>x.ReturnDate);
            RuleFor(x => x.DepartureDate).NotEmpty().GreaterThanOrEqualTo(x => x.DepartureDate);
            RuleFor(x => x.DeparturePort).NotEmpty();
        }
    }
}

﻿using AltexTravel.API.DAL.Queries.Features.Recommendations;
using FluentValidation;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public class RecommendationValidator : AbstractValidator<RecommendationQuery>
    {
        public RecommendationValidator()
        {
            RuleFor(x => x.ArrivalPort).NotEmpty();
            RuleFor(x => x.Cabin).NotEmpty();
            RuleFor(x => x.DemandDirectFlight).NotEmpty();
            RuleFor(x => x.ReturnDate).NotEmpty();
            RuleFor(x => x.DepartureDate).NotEmpty();
            RuleFor(x => x.DeparturePort).NotEmpty();
        }
    }
}

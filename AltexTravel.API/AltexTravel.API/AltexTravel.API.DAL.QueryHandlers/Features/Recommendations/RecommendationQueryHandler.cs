using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Queries.Features.Recommendations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public class RecommendationQueryHandler : BaseQueryHandler<RecommendationQuery, RecommendationQueryResponce>
    {
        private readonly TravelContext _context;

        public RecommendationQueryHandler(IValidator<RecommendationQuery> validator, TravelContext context) : base(validator)
        {
            _context = context;
        }

        protected override async Task<RecommendationQueryResponce> HandleAsync(RecommendationQuery request, CancellationToken cancellationToken)
            => DefaultSearchResult.GetDefaultSearch();
        
    }
}

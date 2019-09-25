using AltexTravel.API.Amadeus;
using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Features.SearchResult;
using AltexTravel.API.DAL.Queries.Features.Recommendations;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public class RecommendationQueryHandler : BaseQueryHandler<RecommendationQuery, RecommendationQueryResponce>
    {
        private readonly TravelContext _context;
        private readonly AmadeusManager _amadeusManager;

        public RecommendationQueryHandler(IValidator<RecommendationQuery> validator, TravelContext context, AmadeusManager amadeusManager) : base(validator)
        {
            _context = context;
            _amadeusManager = amadeusManager;
        }

        protected override async Task<RecommendationQueryResponce> HandleAsync(RecommendationQuery request, CancellationToken cancellationToken)
        {
            var searchResult = await _amadeusManager.GetSearchResultAsync(SearchQueryToUrl.GetUrlPath(request));
            if (searchResult.Data==null)
            {
                return new RecommendationQueryResponce();
            }
            return searchResult.ToDomain(request).GetFiltration(request).GetLocation(_context);
        }
    }
}

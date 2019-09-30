using AltexTravel.API.Amadeus;
using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Features.SearchResult;
using AltexTravel.API.DAL.Queries.Features.Recommendations;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Recommendations
{
    public class RecommendationQueryHandler : BaseQueryHandler<RecommendationQuery, RecommendationQueryResponce>
    {
        private readonly TravelContext _context;
        private readonly AmadeusManager _amadeusManager;
        private readonly IMemoryCache _cache;

        public RecommendationQueryHandler(IValidator<RecommendationQuery> validator, TravelContext context, AmadeusManager amadeusManager, IMemoryCache cache) : base(validator)
        {
            _context = context;
            _amadeusManager = amadeusManager;
            _cache = cache;
        }

        protected override async Task<RecommendationQueryResponce> HandleAsync(RecommendationQuery request, CancellationToken cancellationToken)
        {
            var hash = request.GetHash();
            var recommendations = _cache.Get<RecommendationQueryResponce>(hash);
            if (recommendations == null)
            {
                var searchResult = await _amadeusManager.GetSearchResultAsync(request.GetQueryParams());
                if (searchResult.Data == null)
                    return new RecommendationQueryResponce();

                recommendations = searchResult.ToDomain(request)
                    .RecommendationFilrator(request)
                    .GetLocation(_context);

                if (recommendations.FullRecommendations != null)
                    _cache.Set(hash, recommendations, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3)));
            }
            return recommendations;
        }
    }
}

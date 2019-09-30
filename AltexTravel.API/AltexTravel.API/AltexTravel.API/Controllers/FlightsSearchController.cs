using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Mappers;
using AltexTravel.API.Models.SearchResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AltexTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsSearchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;

        public FlightsSearchController(IMediator mediator, IMemoryCache cache)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _cache = cache;
        }

        [HttpGet]
        [ProducesResponseType(typeof(RecommendationsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RoundTrip([FromQuery]RecommendationQuery recommendationQuery)
        {
            var json = JsonConvert.SerializeObject(recommendationQuery);
            var hashCode1 = json.GetHashCode();
            var recommendations = _cache.Get<RecommendationsViewModel>(hashCode1);
            if (recommendations == null)
            {
                var responce = await _mediator.Send(recommendationQuery);
                recommendations = responce.Result?.ToViewModel();
                _cache.Set(hashCode1, recommendations, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3)));
            }
            return new OkObjectResult(recommendations);
        }
    }
}
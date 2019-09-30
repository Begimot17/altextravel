using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.DAL.QueryHandlers.Features.Recommendations;
using AltexTravel.API.Mappers;
using AltexTravel.API.Models.SearchResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nancy.Json;

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
            var json = new JavaScriptSerializer().Serialize(recommendationQuery);
            var recommendations = _cache.Get<RecommendationsViewModel>(json);
            if (recommendations == null)
            {
                var responce = await _mediator.Send(recommendationQuery);
                recommendations = responce.Result?.ToViewModel();
                _cache.Set(json, recommendations, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3)));
            }
            return new OkObjectResult(recommendations);
        }
    }
}
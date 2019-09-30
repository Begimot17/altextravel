using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Mappers;
using AltexTravel.API.Models.SearchResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
            var responce = await _mediator.Send(recommendationQuery);
            var recommendations = responce.Result?.ToViewModel();
            return new OkObjectResult(recommendations);
        }
    }
}
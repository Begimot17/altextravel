using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Mappers;
using AltexTravel.API.Models.SearchResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AltexTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsSearchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlightsSearchController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(typeof(RecommendationsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RoundTrip(RecommendationQuery recommendationQuery)
        {
            var responce = await _mediator.Send(recommendationQuery);
            var result =responce.Result.ToViewModel();
            return new OkObjectResult(result);
        }
    }
}
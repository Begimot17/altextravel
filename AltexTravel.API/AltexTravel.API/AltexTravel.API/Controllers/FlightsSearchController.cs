using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltexTravel.API.DAL.Queries.Features.Recommendations;
using AltexTravel.API.Mappers;
using AltexTravel.API.Models.SearchResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [ProducesResponseType(typeof(List<Domain.Reccomendations.Recommendation>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Domain.Reccomendations.Recommendation>), StatusCodes.Status400BadRequest)]
        public IActionResult RoundTrip(string arrivalPort,
            string cabin, bool demandDirectFlight, string departureDate, string departurePort,
            string returnDate, string currencyCode = null, int maximumNumberOfRecommendations = 0,
            int numberOfAdults = 0, int numberOfChildren = 0, int numberOfInfants = 0
            )
        {

            var request = new RecommendationQuery
            {
                ArrivalPort = arrivalPort,
                CurrencyCode = currencyCode,
                Cabin = cabin,
                DemandDirectFlight = demandDirectFlight,
                DepartureDate = departureDate,
                DeparturePort = departurePort,
                MaximumNumberOfRecommendations = maximumNumberOfRecommendations,
                NumberOfAdults = numberOfAdults,
                NumberOfChildren = numberOfChildren,
                NumberOfInfants = numberOfInfants,
                ReturnDate = returnDate
            };
            var x = new OkObjectResult(DefaultSearchResult.RecommendationQuery().Recommendations);
            return x;
        }
    }
}
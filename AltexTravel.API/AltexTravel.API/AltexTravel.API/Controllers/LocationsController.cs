using AltexTravel.API.DAL.Queries.Features.Locations;
using AltexTravel.API.Mappers;
using AltexTravel.API.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AltexTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<LocationViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<LocationViewModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Locations(string search, int count)
        {
            var request = new LocationQuery { Search = search, Count = count };
            var responce = await _mediator.Send(request);
            var result = responce.Result.Locations.ToViewModel();
            if (result!=null)
            {
                return responce.ToAction(result);
            }
            return responce.ToAction();

        }
    }
}
using AltexTravel.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Locations(string search,int count)
        {
            return Ok();
        }
    }
}
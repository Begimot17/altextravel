using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltexTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelAgentBookingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TravelAgentBookingsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [Route("[controller]/Booking/{id}")]
        [HttpGet]
        public IActionResult Booking(int id)
        {
            return Ok();
        }
        [Route("[controller]/Booking")]
        [HttpGet]
        public IActionResult Booking()
        {
            return Ok();
        }
        [Route("[controller]/Passenger")]
        [HttpPut]
        public IActionResult Passenger()
        {
            return Ok();
        }
    }
}
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
    public class FlightsBookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlightsBookingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [Route("[controller]/Booking/{bookingId}")]
        [HttpGet]
        public IActionResult Booking(int bookingId)
        {
            return Ok();
        }
        [Route("[controller]/Booking")]
        [HttpPost]
        public IActionResult Booking()
        {
            return Ok();
        }
        [Route("[controller]/Booking/{param}")]
        [HttpPut]
        public IActionResult Booking(bool param)
        {
            return Ok();
        }
    }
}
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
    public class FlightsSearchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FlightsSearchController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [Route("[controller]/Multicity")]

        [HttpGet]
        public async Task<IActionResult> Multicity()
        {
            return Ok();
        }
        [Route("[controller]/Roundtrip")]

        [HttpGet]
        public async Task<IActionResult> Roundtrip()
        {
            return Ok();
        }
        [Route("[controller]/Oneway")]

        [HttpGet]
        public IActionResult Oneway()
        {
            return Ok();
        }
    }
}
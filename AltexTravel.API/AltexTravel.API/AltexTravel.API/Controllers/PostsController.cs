using AltexTravel.API.Commands;
using AltexTravel.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AltexTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IQueries _queries;
        private readonly IMediator _mediator;
        private readonly ICommandService _commands;
        public PostsController(IMediator mediator, IQueries queries, ICommandService commands)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }
        [HttpPost]
        public async Task<IActionResult> Method(string returnUrl = null)
        {
            return Ok();
        }
    }
}
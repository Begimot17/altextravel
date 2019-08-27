using AltexTravel.API.Commands;
using AltexTravel.API.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AltexTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IQueriesService _queries;
        private readonly ICommandService _commands;
        public PostsController(IQueriesService queries, ICommandService commands)
        {
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
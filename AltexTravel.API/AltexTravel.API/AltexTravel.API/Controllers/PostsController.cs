using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtexTravel.API.Commands;
using AtexTravel.API.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
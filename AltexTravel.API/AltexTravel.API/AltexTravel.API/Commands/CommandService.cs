using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Commands
{
    public class CommandService : ICommandService
    {
        public Task SavePost(string title, string body)
        {
            throw new NotImplementedException();
        }
    }
}

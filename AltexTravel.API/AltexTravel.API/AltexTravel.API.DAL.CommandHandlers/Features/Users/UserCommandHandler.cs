using AltexTravel.API.DAL.Commands.Features.Users;
using MediatR;
using System;
using System.Threading;
using FluentValidation;
using System.Threading.Tasks;
using AltexTravel.API.DAL.BaseHandlers;

namespace AltexTravel.API.DAL.CommandHandlers.Features.Users
{
    public class UserCommandHandler: BaseCommandHandler<UserCommand>
    {
        public UserCommandHandler(IValidator<UserCommand> validator) :
        base(validator)
        {
        }
        protected override Task HandleAsync(UserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

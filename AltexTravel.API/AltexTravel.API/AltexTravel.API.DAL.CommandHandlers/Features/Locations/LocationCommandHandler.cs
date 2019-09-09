using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Commands.Features.Locations;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.CommandHandlers.Features.Locations
{
    public class LocationCommandHandler : BaseCommandHandler<LocationCommand>
    {
        public LocationCommandHandler(IValidator<LocationCommand> validator) : base(validator)
        {

        }

        protected override Task HandleAsync(LocationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

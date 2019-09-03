using AltexTravel.API.DAL.BaseHandlers;
using MediatR;

namespace AltexTravel.API.DAL.Commands.Features.Users
{
    public class UserCommand : IRequest<ValidatedEmptyResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

using MediatR;

namespace AltexTravel.API.DAL.Commands.Features.Users
{
    public class UserCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

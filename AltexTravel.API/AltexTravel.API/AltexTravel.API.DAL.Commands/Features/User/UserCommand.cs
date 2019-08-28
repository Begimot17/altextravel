using MediatR;

namespace AltexTravel.API.DAL.Commands.Features.User
{
    public class UserCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

using AltexTravel.API.DAL.BaseHandlers;
using MediatR;

namespace AltexTravel.API.DAL.Queries.Features.Users
{
    public class UserQuery:IRequest<ValidatedResponse<bool>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

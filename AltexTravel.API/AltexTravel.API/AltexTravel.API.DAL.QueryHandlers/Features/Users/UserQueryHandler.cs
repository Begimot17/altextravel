using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Queries.Features.Users;
using AltexTravel.API.Domain;
using FluentValidation;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Users
{
    public class UserQueryHandler : BaseQueryHandler<UserQuery, bool>
    {
        public UserQueryHandler(IValidator<UserQuery> validator) :
        base(validator)
        {
        }

        protected override Task<bool> HandleAsync(UserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

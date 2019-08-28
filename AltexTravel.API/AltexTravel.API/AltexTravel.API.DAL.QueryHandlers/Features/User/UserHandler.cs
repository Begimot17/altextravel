using AltexTravel.API.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltexTravel.API.DAL.QueryHandlers.Features.User
{
    public class UserHandler : BaseRepository, IRequest<Domain.User>
    {
        public Domain.User GetUser(string id)
        {
            Domain.User userDomain = null;
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(id));
                userDomain = new Domain.User { Id = user.Id, Name = user.Name };
            });
            return userDomain;
        }
    }
}

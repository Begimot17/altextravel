using AltexTravel.API.DAL.Queries.Features.User;
using AltexTravel.API.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltexTravel.API.DAL.QueryHandlers.Features.User
{
    public class UserHandler : BaseRepository, IRequest<UserQuery>
    {
        public UserQuery GetUser(string id)
        {
            UserQuery userDomain = null;
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(id));
                userDomain = new UserQuery { Id = user.Id, Name = user.Name };
            });
            return userDomain;
        }
    }
}

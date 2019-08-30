using AltexTravel.API.DAL.Queries.Features.Users;
using MediatR;
using System;
using System.Linq;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Users
{
    public class UserHandler :IRequest<UserQuery>
    {
        public UserQuery GetUser(string id)
        {
            UserQuery userDomain = null;
            //WithContext(context =>
            //{
            //    var user = context.Users.Single(x => x.Id.Equals(id));
            //    userDomain = new UserQuery { Id = user.Id, Name = user.Name };
            //});
            return userDomain;
        }
    }
}

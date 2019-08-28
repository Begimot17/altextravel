using AltexTravel.API.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltexTravel.API.DAL.QueryHandlers.Features.User
{
    public class UserHandler : BaseRepository, IRequest<UserDomain>
    {
        public UserDomain GetUser(string id)
        {
            UserDomain userDomain = null;
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(id));
                userDomain = new UserDomain { Id = user.Id, Name = user.Name };
            });
            return userDomain;
        }
    }
}

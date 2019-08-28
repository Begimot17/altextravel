using AltexTravel.API.DAL.Commands.Features.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AltexTravel.API.DAL.CommandHandlers.Features.User
{
    public class UserHandler:BaseRepository ,IRequest<UserCommand>
    {
        public void Update(UserCommand model)
        {
            WithContext(context =>
            {
                var user = context.Users.Single(x => x.Id.Equals(model.Id));
                user.Id = model.Id;
                user.Name = model.Name;
                context.SaveChanges();
            });
        }
    }
}

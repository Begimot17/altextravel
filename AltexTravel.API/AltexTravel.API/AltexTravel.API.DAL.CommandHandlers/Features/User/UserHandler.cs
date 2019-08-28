using AltexTravel.API.DAL.Commands.Features.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.CommandHandlers.Features.User
{
    public class UserHandler:BaseRepository, IRequestHandler<UserCommand, bool>
    {
        public Task<bool> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

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

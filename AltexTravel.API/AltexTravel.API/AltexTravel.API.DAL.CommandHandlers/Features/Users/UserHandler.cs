using AltexTravel.API.DAL.Commands.Features.Users;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.CommandHandlers.Features.Users
{
    public class UserHandler:IRequest<UserCommand>
    {
        public void Update(UserCommand model)
        {
                //WithContext(context =>
                //{
                //    var user = context.Users.Single(x => x.Id.Equals(model.Id));
                //    user.Name = model.Name;
                //    context.SaveChanges();
                //});
        }
    }
}

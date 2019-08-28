using AltexTravel.API.Domain;
using AltexTravel.API.DAL.Features.User;

namespace AltexTravel.API.DAL.BaseHandlers.Features.User
{
    public static class UserMapper
    {
        public static DAL.Features.User.User ToEntity(Domain.User model)
        {
            return new DAL.Features.User.User
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public static Domain.User ToDomain(DAL.Features.User.User model)
        {
            return new Domain.User
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}

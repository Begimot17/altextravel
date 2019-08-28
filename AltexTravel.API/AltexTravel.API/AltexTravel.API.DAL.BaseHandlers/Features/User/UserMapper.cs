using AltexTravel.API.DAL.Entity;
using AltexTravel.API.Domain.Models;

namespace AltexTravel.API.DAL.BaseHandlers.Features.User
{
    public class UserMapper
    {
        public User ToEntity(UserDomain model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public UserDomain ToDto(User model)
        {
            return new UserDomain
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}

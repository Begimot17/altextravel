using AltexTravel.API.DAL.Entity;
using AltexTravel.API.Dtos.User;

namespace AltexTravel.API.DAL.Features.User
{
    public class UserMapper
    {
        public User ToEntity(UserDto model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public UserDto ToDto(User model)
        {
            return new UserDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}

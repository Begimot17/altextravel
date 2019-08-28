using AltexTravel.API.DAL.Features.User;
using AltexTravel.API.Dtos.Features.User;

namespace AltexTravel.API.DAL.Mappers
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

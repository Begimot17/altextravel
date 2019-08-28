using AltexTravel.API.DAL.Entity;
using AltexTravel.API.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

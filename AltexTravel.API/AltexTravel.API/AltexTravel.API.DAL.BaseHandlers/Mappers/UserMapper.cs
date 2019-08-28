using AltexTravel.API.DAL.Entity;
using AltexTravel.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.BaseHandlers.Mappers
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

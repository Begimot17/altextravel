using AltexTravel.API.Domain;

namespace AltexTravel.API.DAL.BaseHandlers.Features.Users
{
    public static class UserMapper
    {
        public static User ToEntity(Domain.User model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name
            };
        }
        public static Domain.User ToDomain(User model)
        {
            return new Domain.User
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}

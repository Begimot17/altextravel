using AltexTravel.API.DAL.Queries.Features.Users;
using FluentValidation;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Users
{
    public class UserValidator : AbstractValidator<UserQuery>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}

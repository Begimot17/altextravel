using AltexTravel.API.DAL.Commands.Features.Users;
using FluentValidation;

namespace AltexTravel.API.DAL.CommandHandlers.Features.Users
{
    public class UserValidator : AbstractValidator<UserCommand>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}

using AltexTravel.API.DAL.Commands.Features.User;
using FluentValidation;

namespace AltexTravel.API.DAL.CommandHandlers.Features.User
{
    public class UserValidator : AbstractValidator<UserCommand>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}

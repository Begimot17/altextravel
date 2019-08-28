using AltexTravel.API.DAL.Queries.Features.User;
using FluentValidation;

namespace AltexTravel.API.Models
{
    public class UserValidator : AbstractValidator<UserQuery>
    {
        public UserValidator()
        {
            RuleFor(customer => customer.Name).NotNull();
        }
    }
}

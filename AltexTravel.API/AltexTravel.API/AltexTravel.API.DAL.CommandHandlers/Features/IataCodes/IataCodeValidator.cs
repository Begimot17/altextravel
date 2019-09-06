using AltexTravel.API.DAL.Commands.Features.IataCodes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AltexTravel.API.DAL.CommandHandlers.Features.IataCodes
{
    public class IataCodeValidator : AbstractValidator<IataCodeCommand>
    {
        public IataCodeValidator()
        {
            RuleFor(x => x.ArrivalLocation).NotNull().WithMessage("Error");
            RuleFor(x => x.ArrivalLocation).MaximumLength(100).WithMessage("Error");
            RuleFor(x => x.ArrivalLocation).Matches(new Regex(@"^[A-Za-z0-9-\s\'\,\""\(\)]+$"))
                .WithMessage(@"Email can only contain an allowed characters: A-Z  a-z space 0-9 ' , ""() ");
            RuleFor(x => x.DepartureLocation).NotNull().WithMessage("Error");
            RuleFor(x => x.DepartureLocation).MaximumLength(100).WithMessage("Error");
            RuleFor(x => x.DepartureLocation).Matches(new Regex(@"^[A-Za-z0-9-\s\'\,\""\(\)]+$"))
                .WithMessage(@"Email can only contain an allowed characters: A-Z  a-z space 0-9 ' , ""() ");
        }
    }
}

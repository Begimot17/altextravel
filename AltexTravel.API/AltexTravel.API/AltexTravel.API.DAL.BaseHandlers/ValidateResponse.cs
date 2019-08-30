using System.Collections.Generic;
using FluentValidation.Results;
using MediatR;

namespace AltexTravel.API.DAL.BaseHandlers
{
    public class ValidatedResponse<TResponse>
    {
        public virtual bool IsValid { get; }
        public IList<ValidationFailure> Errors { get; }
        public TResponse Result { get; set; }
    }
}
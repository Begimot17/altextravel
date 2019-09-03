using System.Collections.Generic;
using FluentValidation.Results;
using MediatR;

namespace AltexTravel.API.DAL.BaseHandlers
{
    public class ValidatedResponse<TResponse>
    {
        public bool IsValid { get; set; }
        public IList<ValidationFailure> Errors { get; set; }
        public TResponse Result { get; set; }
    }
    public class ValidatedEmptyResponse : ValidatedResponse<Empty>
    {

    }

    public class Empty
    {

    }
}
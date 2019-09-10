using FluentValidation.Results;
using System.Collections.Generic;

namespace AltexTravel.API.DAL.BaseHandlers
{
    public class ValidatedResponse<TResponse>
    {
        public bool IsValid { get; set; }
        public IList<ValidationFailure> Errors { get; set; }
        public TResponse Result { get; set; }
    }
}
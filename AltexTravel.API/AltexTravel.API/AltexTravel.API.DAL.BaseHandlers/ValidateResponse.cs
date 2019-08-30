using System.Collections.Generic;
using FluentValidation.Results;

public class ValidateResponse<TResult>
{
    public virtual bool IsValid { get; }
    public IList<ValidationFailure> Errors { get; }
    public TResult Result { get; set; }
}
}

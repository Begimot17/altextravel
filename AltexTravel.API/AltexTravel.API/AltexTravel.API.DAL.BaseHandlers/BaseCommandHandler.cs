using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.BaseHandlers
{
    public abstract class BaseCommandHandler<TRequest ,ValidateResponse<TResponse>> :  ValidateResponse<TResponse>, IRequestHandler<TRequest> 
        {   private readonly IValidator<TRequest> _validator;

    protected BaseCommandHandler(IValidator<TRequest> validator)
    {
        _validator = validator;
    }
    protected abstract Task<ValidateResponse<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
    public Task<ValidateResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var validationRezult = _validator.Validate(request);
        return HandleAsync(request, cancellationToken);
    }
}


public class ValidateResponse<TResult>
{
    public virtual bool IsValid { get; }
    public IList<ValidationFailure> Errors { get; }
    public TResult Result { get; set; }
}
}


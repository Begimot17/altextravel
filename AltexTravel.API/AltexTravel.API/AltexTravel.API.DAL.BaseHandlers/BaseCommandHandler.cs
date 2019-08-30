using System.Threading;
using System.Threading.Tasks;
using AltexTravel.API.Domain;
using FluentValidation;
using MediatR;

namespace AltexTravel.API.DAL.BaseHandlers
{
    public abstract class BaseCommandHandler<TRequest, ValidateResponse<TResponse>> : IRequestHandler<TRequest, ValidateResponse<TResponse>> where TRequest : IRequest<ValidateResponse<TResponse>>
    {
        private readonly IValidator<TRequest> _validator;

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
}
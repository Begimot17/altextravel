using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace AltexTravel.API.DAL.BaseHandlers
{
    public abstract class BaseQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, ValidatedResponse<TResponse>>
        where TRequest : IRequest<ValidatedResponse<TResponse>>
    {
        private readonly IValidator<TRequest> _validator;

        protected BaseQueryHandler(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        protected abstract Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken);

        public async Task<ValidatedResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new ValidatedResponse<TResponse>
                {
                    IsValid = false,
                    Errors = validationResult.Errors
                };
            }
            var result = await HandleAsync(request, cancellationToken);
            return new ValidatedResponse<TResponse>
            {
                Result = result,
                IsValid = true
            };
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using AltexTravel.API.Domain;
using FluentValidation;
using MediatR;

namespace AltexTravel.API.DAL.BaseHandlers
{
    public abstract class BaseCommandHandler<TRequest> : IRequestHandler<TRequest, ValidatedEmptyResponse>
        where TRequest : IRequest<ValidatedEmptyResponse>
    {
        private readonly IValidator<TRequest> _validator;

        protected BaseCommandHandler(IValidator<TRequest> validator)
        {
            _validator = validator;
        }
        protected abstract Task HandleAsync(TRequest request, CancellationToken cancellationToken);
        public async Task<ValidatedEmptyResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new ValidatedEmptyResponse
                {
                    IsValid = false,
                    Errors = validationResult.Errors
                };
            }
            await HandleAsync(request, cancellationToken);
            return new ValidatedEmptyResponse
            {
                IsValid = true
            };
        }

    }

}
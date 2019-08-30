using System.Threading;
using System.Threading.Tasks;
using AltexTravel.API.Domain;
using FluentValidation;
using MediatR;

namespace AltexTravel.API.DAL.BaseHandlers
{
    public abstract class BaseCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, ValidatedResponse<TResponse>>
        where TRequest : IRequest<ValidatedResponse<TResponse>>
    {
        private readonly IValidator<TRequest> _validator;

        protected BaseCommandHandler(IValidator<TRequest> validator)
        {
            _validator = validator;
        }
        protected abstract Task<ValidatedResponse<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
        public Task<ValidatedResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);


            return HandleAsync(request, cancellationToken);
        }

    }

}
using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Queries.Features.IataCodes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.QueryHandlers.Features.IataCodes
{
    public class IataCodeQueryHandler : BaseQueryHandler<IataCodeQuery, bool>
    {
        public IataCodeQueryHandler(IValidator<IataCodeQuery> validator) : base(validator)
        {

        }

        protected override Task<bool> HandleAsync(IataCodeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using AltexTravel.API.DAL.BaseHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL.Queries.Features.IataCodes
{
    public class IataCodeQuery : IRequest<ValidatedResponse<bool>>
    {
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
    }
}

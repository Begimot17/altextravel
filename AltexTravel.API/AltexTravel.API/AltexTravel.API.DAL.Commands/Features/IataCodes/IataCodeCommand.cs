using AltexTravel.API.DAL.BaseHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL.Commands.Features.IataCodes
{
    public class IataCodeCommand : IRequest<ValidatedEmptyResponse>
    {
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
    }
}

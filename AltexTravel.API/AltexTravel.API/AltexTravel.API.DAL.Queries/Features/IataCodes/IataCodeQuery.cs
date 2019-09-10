using AltexTravel.API.DAL.BaseHandlers;
using MediatR;

namespace AltexTravel.API.DAL.Queries.Features.IataCodes
{
    public class IataCodeQuery : IRequest<ValidatedResponse<bool>>
    {
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
    }
}

using AltexTravel.API.DAL.BaseHandlers;
using MediatR;

namespace AltexTravel.API.DAL.Queries.Features.Locations
{
    public class LocationQuery : IRequest<ValidatedResponse<LocationQueryResponce>>
    {
        public int Count { get; set; }
        public string Search { get; set; }
    }
}

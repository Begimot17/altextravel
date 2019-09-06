using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Features.IataCodes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL.Commands.Features.Locations
{
    public class LocationCommand : IRequest<ValidatedEmptyResponse>
    {
        public List<IataCode> Airports { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}

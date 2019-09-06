using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.Queries.Features.IataCodes;
using AltexTravel.API.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL.Queries.Features.Locations
{
    public class LocationQuery : IRequest<ValidatedResponse<LocationQueryResponce>>
    {
        public int Count { get; set; }
        public string Search { get; set; }
    }
}

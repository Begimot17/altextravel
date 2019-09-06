﻿using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.BaseHandlers.Mappers;
using AltexTravel.API.DAL.Queries.Features.Locations;
using AltexTravel.API.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.QueryHandlers.Features.Locations
{
    public class LocationQueryHandler : BaseQueryHandler<LocationQuery, LocationQueryResponce>
    {
        private readonly TravelContext _context;

        public LocationQueryHandler(IValidator<LocationQuery> validator, TravelContext context) : base(validator)
        {
            _context = context;
        }
        public async Task<LocationQueryResponce> Handle(LocationQuery request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }
        protected override async Task<LocationQueryResponce> HandleAsync(LocationQuery request, CancellationToken cancellationToken)
        {
            var airports = await _context.IataCodes.Select(x => x).ToListAsync(cancellationToken);
            var locations = await _context.Locations.Where(x => x.Name.Contains(request.Search)).Take(request.Count).ToListAsync(cancellationToken);
            //foreach (var loc in locations)
            //{
            //    foreach (var air in airports)
            //    {
            //        if (air.Location.Id==loc.Id)
            //        {
            //            loc.Airports.Add(air);
            //        }
            //    }
            //}
            return new LocationQueryResponce { Locations = locations.ToDomain() };
        }
    }
}

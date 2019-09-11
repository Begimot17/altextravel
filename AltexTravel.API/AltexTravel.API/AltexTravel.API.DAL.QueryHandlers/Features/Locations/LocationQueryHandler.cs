﻿using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.DAL.BaseHandlers.Mappers;
using AltexTravel.API.DAL.Queries.Features.Locations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        protected override async Task<LocationQueryResponce> HandleAsync(LocationQuery request, CancellationToken cancellationToken)
        {
            var locations = await _context.Locations
                .AsNoTracking()
                .Include(x => x.Airports)
                .Where(x => x.Name.Contains(request.Search) || x.Code.Contains(request.Search))
                .Take(request.Count)
                .ToListAsync(cancellationToken);
            return new LocationQueryResponce
            {
                Locations = locations.ToDomain()
            };
        }
    }
}

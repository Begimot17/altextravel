using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL.Features.SearchResult
{
    public class LocationsFromDb
    {
        private static TravelContext _context;

        public LocationsFromDb(TravelContext context)
        {
            _context = context;
        }
        public static IataCode GetLocations(string code)
        {
            var local = _context.IataCodes
                 .AsNoTracking()
                 .Include(x => x.Location)
                 .First(x => x.Code.Contains(code));
            return local;
        }
    }
}

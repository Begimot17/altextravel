using AltexTravel.API.DAL.Features.IataCodes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

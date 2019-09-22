using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
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
        public static Location GetLocations(string code)
        {
            var local = _context.Locations
                 .AsNoTracking()
                 .First(x => x.Code.Contains(code));
            return local;
        }
    }
}

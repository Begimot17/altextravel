using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using Microsoft.EntityFrameworkCore;

namespace AltexTravel.API.DAL
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public DbSet<IataCode> IataCodes { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}

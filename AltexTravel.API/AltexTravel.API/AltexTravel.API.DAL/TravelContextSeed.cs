using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL
{
    public static class TravelContextSeed
    {

        public static void SeedAsync(TravelContext context)
        {
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(DefaultLocations.GetLocations());
                    context.SaveChangesAsync();
                }
        }
    }
}

using AltexTravel.API.Amadeus;
using AltexTravel.API.DAL.Features.Locations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL
{
    public class TravelContextSeed
    {

        public async Task SeedAsync(TravelContext context, AmadeusManager amadeusManager)
        {
            try
            {
                if (!context.Locations.Any())
                {
                    var locations = amadeusManager.GetLocations().GetAwaiter().GetResult().ToLocation().ToList();
                    context.Locations.AddRange(locations);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

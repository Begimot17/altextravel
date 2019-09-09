using AltexTravel.API.Amadeus;
using AltexTravel.API.DAL.Features.Locations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL
{
    public  class TravelContextSeed
    {

        public async Task SeedAsync(TravelContext context)
        {
            try
            {
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(AmadeusManager.GetLocations().ToLocation());
                    await context.SaveChangesAsync();
                }
                if (!context.IataCodes.Any())
                {
                    context.IataCodes.AddRange(AmadeusManager.GetIatas().ToIata());
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

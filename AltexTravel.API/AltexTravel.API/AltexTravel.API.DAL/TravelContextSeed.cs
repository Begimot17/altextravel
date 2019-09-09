using AltexTravel.API.DAL.Amadeus;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL
{
    public class TravelContextSeed
    {

        public async Task SeedAsync(TravelContext context)
        {
            try
            {
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(AmadeusManager.GetLocations());
                    await context.SaveChangesAsync();
                }
                if (!context.IataCodes.Any())
                {
                    context.IataCodes.AddRange(AmadeusManager.GetIatas());
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

using AltexTravel.API.Amadeus;
using AltexTravel.API.DAL.Features.Locations;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
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
                    var locations = amadeusManager.GetLocations().GetAwaiter().GetResult().ToLocation();
                    await context.BulkInsertAsync(locations.Distinct());
                }
                if (!context.IataCodes.Any())
                {

                    await context.BulkInsertAsync(amadeusManager.GetIatas().GetAwaiter().GetResult().ToIata().Distinct());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

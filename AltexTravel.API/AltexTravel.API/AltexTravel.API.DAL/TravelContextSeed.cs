using AltexTravel.API.Amadeus;
using AltexTravel.API.DAL.Features.IataCodes;
using AltexTravel.API.DAL.Features.Locations;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                    var distLocal = locations.Distinct(new RouteRelComparerLocal()).ToList();
                    foreach (var iata in distLocal)
                    {
                        if (iata.Airports!=null)
                        {
                            iata.Airports.Distinct(new RouteRelComparerIata());
                        }
                    }
                    context.Locations.AddRange(distLocal);
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

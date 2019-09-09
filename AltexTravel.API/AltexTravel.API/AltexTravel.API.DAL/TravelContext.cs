using AltexTravel.API.DAL.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace AltexTravel.API.DAL
{
    public class TravelContext:DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

    public TravelContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    } 
}

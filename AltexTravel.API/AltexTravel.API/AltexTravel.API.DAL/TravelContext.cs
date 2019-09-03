using AltexTravel.API.DAL.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace AltexTravel.API.DAL
{
    public class TravelContext:DbContext
    {
        public TravelContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AltexTravel.API;Trusted_Connection=True;");
        }

        public DbSet<User> Users { get; set; }
    } 
}

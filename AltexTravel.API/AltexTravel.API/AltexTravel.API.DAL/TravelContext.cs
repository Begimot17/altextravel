using AltexTravel.API.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltexTravel.API.DAL
{
    public class TravelContext:DbContext
    {
        public TravelContext()
                : base("name=TravelContext")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}

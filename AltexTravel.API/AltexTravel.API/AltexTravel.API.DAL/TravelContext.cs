using AltexTravel.API.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

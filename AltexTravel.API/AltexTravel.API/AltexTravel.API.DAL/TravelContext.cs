using AltexTravel.API.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTravel.API.DAL
{
    public class TravelContext:DBContext
    {
        public TravelContext()
                : base("name=TravelContext")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}

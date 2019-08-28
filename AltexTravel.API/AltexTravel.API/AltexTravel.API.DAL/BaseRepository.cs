using System;
using System.Collections.Generic;
using System.Text;

namespace AltexTravel.API.DAL
{
    public class BaseRepository
    {
        protected void WithContext(Action<TravelContext> handler)
        {
            using (var context = new TravelContext())
            {
                handler(context);
            }
        }
    }
}

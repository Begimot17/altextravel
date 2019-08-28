using AltexTravel.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Queries
{
    public interface IQueries
    {
        Task<UserViewModel> GetOrderAsync(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AltexTravel.API.Models;

namespace AltexTravel.API.Queries
{
    public class Queries : IQueries
    {
        private string _connectionString = string.Empty;
        public Queries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public Task<User> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

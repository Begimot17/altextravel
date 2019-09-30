using AltexTravel.API.DAL.Queries.Features.Recommendations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AltexTravel.API.Mappers
{
    public static class QueryToHash
    {
        public static string GetHash(this RecommendationQuery query)
        {
            var json = JsonConvert.SerializeObject(query);
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(json));
            return Convert.ToBase64String(hash);
        }
    }
}

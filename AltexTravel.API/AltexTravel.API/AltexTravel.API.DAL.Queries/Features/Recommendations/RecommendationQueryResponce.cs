using AltexTravel.API.Domain.RecomendationsModel;
using System.Collections.Generic;

namespace AltexTravel.API.DAL.Queries.Features.Recommendations
{
    public class RecommendationQueryResponce
    {
        public List<Recommendation> FullRecommendations { get; set; }
    }
}

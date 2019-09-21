using AltexTravel.API.DAL.BaseHandlers;
using MediatR;

namespace AltexTravel.API.DAL.Queries.Features.Recommendations
{
    public class RecommendationQuery : IRequest<ValidatedResponse<RecommendationQueryResponce>>
    {
        public string ReturnDate { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalPort { get; set; }
        public string DeparturePort { get; set; }
        public string Cabin { get; set; }
        public string CurrencyCode { get; set; }
        public bool DemandDirectFlight { get; set; }
        public int MaximumNumberOfRecommendations { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfInfants { get; set; }
    }
}

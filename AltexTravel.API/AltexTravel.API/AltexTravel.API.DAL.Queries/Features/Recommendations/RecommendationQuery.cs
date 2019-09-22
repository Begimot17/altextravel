using AltexTravel.API.DAL.BaseHandlers;
using AltexTravel.API.Domain.RecomendationsModel;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace AltexTravel.API.DAL.Queries.Features.Recommendations
{
    public class RecommendationQuery : IRequest<ValidatedResponse<RecommendationQueryResponce>>
    {
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public string ArrivalPort { get; set; }
        [Required]
        public string DeparturePort { get; set; }
        [Required]
        public Cabins Cabin { get; set; }
        public string CurrencyCode { get; set; }
        public bool DemandDirectFlight { get; set; }
        public int MaximumNumberOfRecommendations { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfInfants { get; set; }
    }
}

using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetTravelItineraryByIdQuery : IRequest<TravelItinerary>
    {
        public int Id { get; set; }
    }
}

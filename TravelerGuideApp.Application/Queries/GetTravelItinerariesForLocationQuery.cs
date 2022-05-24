using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetTravelItinerariesForLocationQuery : IRequest<IEnumerable<TravelItinerary>>
    {
        public int locationId { get; set; }
    }
}

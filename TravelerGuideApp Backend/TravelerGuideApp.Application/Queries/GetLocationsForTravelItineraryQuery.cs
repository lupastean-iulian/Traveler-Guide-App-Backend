using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetLocationsForTravelItineraryQuery : IRequest<IEnumerable<Location>>
    {
        public int travelItineraryId { get; set; }
    }
}

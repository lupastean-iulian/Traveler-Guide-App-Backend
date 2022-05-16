using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class AddLocationsToTravelItinerary : IRequest<int>
    {
        public int TravelItineraryId { get; set; }
        public int LocationId { get; set; }
        public TravelItinerary TravelItinerary { get; set; }
        public Location Location { get; set; }
    }
}

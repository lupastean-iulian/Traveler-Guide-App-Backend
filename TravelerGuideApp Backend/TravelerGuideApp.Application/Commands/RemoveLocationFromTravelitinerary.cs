using MediatR;
namespace TravelerGuideApp.Application.Commands
{
    public class RemoveLocationFromTravelitinerary : IRequest<int>
    {
        public int travelItineraryId { get; set; }
        public int LocationId { get; set; }
    }
}

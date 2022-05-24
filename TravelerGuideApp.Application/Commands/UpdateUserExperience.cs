using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class UpdateUserExperience : IRequest<UserExperience>
    {
        public int UserId { get; set; }
        public int TravelItineraryId { get; set; }
        public int LocationId { get; set; }
        public User User { get; set; }
        public TravelItinerary TravelItinerary { get; set; }
        public Location Location { get; set; }
        public string Priority { get; set; }
        public double Budget { get; set; }
        public string Description { get; set; }
    }
}

using MediatR;

namespace TravelerGuideApp.Application.Commands
{
    public class DeleteUserExperience : IRequest<int>
    {
        public int UserId { get; set; }
        public int TravelItineraryId { get; set; }
        public int LocationId { get; set; }
    }
}

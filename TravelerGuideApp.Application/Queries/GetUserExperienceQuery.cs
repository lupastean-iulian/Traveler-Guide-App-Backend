using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetUserExperienceQuery : IRequest<UserExperience>
    {
        public int UserId { get; set; }
        public int TravelItineraryId { get; set; }
        public int LocationId { get; set; }
    }
}

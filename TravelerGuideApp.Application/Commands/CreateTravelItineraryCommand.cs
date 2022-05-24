using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class CreateTravelItineraryCommand : IRequest<TravelItinerary>
    {
        public string? Name { get; set; }
        public string? Status { get; set; }
        public DateTime TravelDate { get; set; }
        public int UserId { get; set; }
    }
}

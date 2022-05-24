using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class UpdateTravelItineraryCommand : IRequest<TravelItinerary>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public DateTime TravelDate { get; set; }
    }
}

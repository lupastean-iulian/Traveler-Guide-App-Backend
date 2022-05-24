using MediatR;

namespace TravelerGuideApp.Application.Commands
{
    public class DeleteTravelItineraryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

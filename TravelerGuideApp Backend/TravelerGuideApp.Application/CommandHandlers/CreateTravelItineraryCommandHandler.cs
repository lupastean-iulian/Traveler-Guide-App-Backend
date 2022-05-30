using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class CreateTravelItineraryCommandHandler : IRequestHandler<CreateTravelItineraryCommand, TravelItinerary>
    {

        private readonly ITravelItineraryRepository _repository;

        public CreateTravelItineraryCommandHandler(ITravelItineraryRepository repository)
        {
            _repository = repository;
        }
        public Task<TravelItinerary> Handle(CreateTravelItineraryCommand command, CancellationToken cancellationToken)
        {
            var travelItinerary = new TravelItinerary(command.Name, command.Status, command.TravelDate, command.UserId);

            _repository.Create(travelItinerary);
            _repository.Save();
            return Task.FromResult(travelItinerary);
        }
    }
}

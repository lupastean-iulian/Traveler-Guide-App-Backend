using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class UpdateTravelItineraryCommandHandler : IRequestHandler<UpdateTravelItineraryCommand, TravelItinerary>
    {
        private readonly ITravelItineraryRepository _repository;

        public UpdateTravelItineraryCommandHandler(ITravelItineraryRepository repository)
        {
            _repository = repository;
        }

        public Task<TravelItinerary> Handle(UpdateTravelItineraryCommand command, CancellationToken cancellationToken)
        {
            var travelItinerary = _repository.GetById(command.Id);
            if (travelItinerary == null)
            {
                return Task.FromResult(travelItinerary);
            }
            travelItinerary.Name = command.Name;
            travelItinerary.Status = command.Status;
            travelItinerary.TravelDate = command.TravelDate;
            _repository.Update(travelItinerary);
            _repository.Save();
            return Task.FromResult(travelItinerary);
        }
    }
}

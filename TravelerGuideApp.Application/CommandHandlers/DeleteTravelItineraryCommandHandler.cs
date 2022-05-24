using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class DeleteTravelItineraryCommandHandler : IRequestHandler<DeleteTravelItineraryCommand, int>
    {
        private readonly ITravelItineraryRepository _repository;

        public DeleteTravelItineraryCommandHandler(ITravelItineraryRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(DeleteTravelItineraryCommand query, CancellationToken cancellationToken)
        {
            _repository.Delete(query.Id);
            _repository.Save();
            return Task.FromResult(query.Id);
        }
    }
}
using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, int>
    {
        private readonly ILocationRepository _repository;

        public DeleteLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(DeleteLocationCommand query, CancellationToken cancellationToken)
        {
            _repository.Delete(query.Id);
            _repository.Save();
            return Task.FromResult(query.Id);
        }
    }
}

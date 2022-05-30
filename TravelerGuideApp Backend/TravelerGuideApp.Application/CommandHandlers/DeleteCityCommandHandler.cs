using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, int>
    {
        private readonly ICityRepository _repository;

        public DeleteCityCommandHandler(ICityRepository repository)
        {
            _repository = repository;
        }

        public Task<int> Handle(DeleteCityCommand query, CancellationToken cancellationToken)
        {

            _repository.Delete(query.Id);
            _repository.Save();

            return Task.FromResult(query.Id);
        }

    }
}
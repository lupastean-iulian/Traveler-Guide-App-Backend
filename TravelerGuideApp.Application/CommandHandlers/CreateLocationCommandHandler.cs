using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Location>
    {
        private readonly ILocationRepository _repository;

        public CreateLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public Task<Location> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
        {
            var location = new Location(command.CityId, command.Name, command.Address, command.Latitude, command.Longitude);
            _repository.Create(location);
            _repository.Save();
            return Task.FromResult(location);
        }
    }
}

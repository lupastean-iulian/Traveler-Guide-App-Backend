using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, City>
    {
        private readonly ICityRepository _repository;

        public CreateCityCommandHandler(ICityRepository repository)
        {
            _repository = repository;
        }

        public Task<City?> Handle(CreateCityCommand command, CancellationToken cancellationToken)
        {
            var city = new City(command.Name, command.Country);
            _repository.Create(city);
            _repository.Save();
            return Task.FromResult(city);
        }
    }
}

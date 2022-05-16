using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.CommandHandlers
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, City>
    {
        private readonly ICityRepository _repository;

        public UpdateCityCommandHandler(ICityRepository repository)
        {
            _repository = repository;
        }

        public Task<City> Handle(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            var city = _repository.GetById(command.Id);
            if (city == null)
            {
                return Task.FromResult(city);
            }
            city.Name = command.Name;
            city.Country = command.Country;
            _repository.Update(city);
            _repository.Save();
            return Task.FromResult(city);

        }
    }
}
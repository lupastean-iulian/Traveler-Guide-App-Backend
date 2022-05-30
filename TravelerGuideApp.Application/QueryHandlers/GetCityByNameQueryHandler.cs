using MediatR;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetCityByNameQueryHandler : IRequestHandler<GetCityByNameAndCountry, City>
    {
        private readonly ICityRepository _cityRepository;

        public GetCityByNameQueryHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public Task<City> Handle(GetCityByNameAndCountry query, CancellationToken cancellationToken)
        {
            var result = _cityRepository.GetByName(query.Name, query.Country);
            return Task.FromResult(result);

        }
    }
}

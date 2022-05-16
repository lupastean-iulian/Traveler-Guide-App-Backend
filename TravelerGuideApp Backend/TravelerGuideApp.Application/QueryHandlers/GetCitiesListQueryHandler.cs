using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetCitiesListQueryHandler : IRequestHandler<GetCitiesListQuery, IEnumerable<City>>
    {
        private readonly ICityRepository _repository;

        public GetCitiesListQueryHandler(ICityRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<City?>> Handle(GetCitiesListQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetAll();
            return Task.FromResult(result);
        }

    }
}

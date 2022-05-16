using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Location>
    {
        private readonly ILocationRepository _repository;

        public GetLocationByIdQueryHandler(ILocationRepository repository)
        {
            _repository = repository;
        }

        public Task<Location> Handle(GetLocationByIdQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetById(query.Id);

            return Task.FromResult(result);
        }

    }
}
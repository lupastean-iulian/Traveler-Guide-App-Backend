using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetCitiesListQuery : IRequest<IEnumerable<City>>
    {
    }
}

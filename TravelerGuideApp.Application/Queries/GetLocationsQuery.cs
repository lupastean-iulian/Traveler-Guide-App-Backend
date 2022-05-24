using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetLocationsQuery : IRequest<IEnumerable<Location>>
    {

    }
}

using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetLocationsForCity : IRequest<IEnumerable<Location>>
    {
        public int CityId { get; set; }
    }
}

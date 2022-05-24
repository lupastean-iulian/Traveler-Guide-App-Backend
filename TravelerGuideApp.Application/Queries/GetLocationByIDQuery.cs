using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetLocationByIdQuery : IRequest<Location>
    {
        public int Id { get; set; }
    }
}

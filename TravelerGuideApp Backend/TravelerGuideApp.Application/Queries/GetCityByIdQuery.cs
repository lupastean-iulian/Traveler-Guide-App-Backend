using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetCityByIdQuery : IRequest<City>
    {
        public int Id { get; set; }
    }
}

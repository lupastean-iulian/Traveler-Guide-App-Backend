using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetCityByNameAndCountry : IRequest<City>
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}

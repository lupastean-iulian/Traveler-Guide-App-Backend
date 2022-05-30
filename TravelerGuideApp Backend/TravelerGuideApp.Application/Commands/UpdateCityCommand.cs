using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class UpdateCityCommand : IRequest<City>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
    }
}

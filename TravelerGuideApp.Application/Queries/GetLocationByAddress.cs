using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class GetLocationByAddress
        : IRequest<Location>
    {
        public string Address { get; set; }
    }
}
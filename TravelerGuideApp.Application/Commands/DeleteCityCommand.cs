using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Commands
{
    public class DeleteCityCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

using MediatR;

namespace TravelerGuideApp.Application.Commands
{
    public class DeleteLocationCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

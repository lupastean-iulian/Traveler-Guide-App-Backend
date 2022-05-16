using MediatR;

namespace TravelerGuideApp.Application.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

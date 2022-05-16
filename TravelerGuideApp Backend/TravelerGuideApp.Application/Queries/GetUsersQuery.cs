using MediatR;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}

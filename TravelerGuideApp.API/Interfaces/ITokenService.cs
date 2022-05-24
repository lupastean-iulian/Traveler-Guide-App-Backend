using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}

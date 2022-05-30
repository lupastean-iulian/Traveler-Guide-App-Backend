using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetUserByEmailQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<User> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetByEmail(query.Email);
            if (result == null)
                Console.WriteLine(result);
            return Task.FromResult(result);
        }
    }
}
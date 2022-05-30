using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var result = _repository.GetById(query.Id);

            return Task.FromResult(result);
        }
    }
}

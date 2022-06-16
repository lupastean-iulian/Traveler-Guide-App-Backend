using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class TotalBudgetQueryHandler : IRequestHandler<TotalBudget, double>
    {
        private readonly IUserExperience _userRepository;

        public TotalBudgetQueryHandler(IUserExperience userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<double> Handle(TotalBudget query, CancellationToken cancellationToken)
        {
            var result = _userRepository.GetFullBudget(query.userId, query.travelId);
            return Task.FromResult(result);

        }
    }
}

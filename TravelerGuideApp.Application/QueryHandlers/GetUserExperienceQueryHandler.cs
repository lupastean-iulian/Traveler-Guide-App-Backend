using MediatR;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.Application.QueryHandlers
{
    public class GetUserExperienceQueryHandler : IRequestHandler<GetUserExperienceQuery, UserExperience>
    {
        private readonly IUserExperience _userExperience;

        public GetUserExperienceQueryHandler(IUserExperience userExperience)
        {
            _userExperience = userExperience;
        }

        public Task<UserExperience> Handle(GetUserExperienceQuery query, CancellationToken cancellationToken)
        {
            var result =
                _userExperience.GetSpecificUserExperience(query.UserId, query.TravelItineraryId, query.LocationId);
            return Task.FromResult(result);
        }
    }
}

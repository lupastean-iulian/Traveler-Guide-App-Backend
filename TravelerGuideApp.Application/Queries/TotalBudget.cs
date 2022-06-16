using MediatR;

namespace TravelerGuideApp.Application.Queries
{
    public class TotalBudget : IRequest<double>
    {
        public int userId { get; set; }
        public int travelId { get; set; }
    }
}

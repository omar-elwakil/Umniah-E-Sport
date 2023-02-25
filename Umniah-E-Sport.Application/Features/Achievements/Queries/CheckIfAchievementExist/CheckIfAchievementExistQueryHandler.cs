using MediatR;

using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Achievements.Queries.CheckIfAchievementExist
{
    public class CheckIfAchievementExistQueryHandler : IRequestHandler<CheckIfAchievementExistQuery, bool>
    {
        private readonly IAchievementManager _achievementManager;

        public CheckIfAchievementExistQueryHandler(IAchievementManager achievementManager)
        {
            _achievementManager = achievementManager;
        }

        public async Task<bool> Handle(CheckIfAchievementExistQuery request, CancellationToken cancellationToken)
        {
            return await _achievementManager.GetAsync(request.Id) != null;
        }
    }
}

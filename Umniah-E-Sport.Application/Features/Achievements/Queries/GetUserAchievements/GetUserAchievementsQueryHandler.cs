using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserAchievements
{
    public class GetUserAchievementsQueryHandler : IRequestHandler<GetUserAchievementsQuery, List<GetUserAchievementsVm>>
    {
        private readonly IAchievementManager _achievementManager;
        private readonly IMapper _mapper;

        public GetUserAchievementsQueryHandler(IAchievementManager achievementManager, IMapper mapper)
        {
            _achievementManager = achievementManager;
            _mapper = mapper;
        }

        public Task<List<GetUserAchievementsVm>> Handle(GetUserAchievementsQuery request, CancellationToken cancellationToken)
        {
            var achievements = _achievementManager.GetUserAchievementsByMsisdn(request.Msisdn);
            var achievementsVm = _mapper.Map<List<GetUserAchievementsVm>>(achievements);
            return Task.FromResult(achievementsVm);
        }
    }
}

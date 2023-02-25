using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Achievements.Queries.GetUserAchievementsByUserId
{
    public class GetUserAchievementsByUserIdQueryhandler : IRequestHandler<GetUserAchievementsByUserIdQuery,List<GetUserAchievementsByUserIdVm>>
    {
        private readonly IAchievementManager _achievementManager;
        private readonly IMapper _mapper;

        public GetUserAchievementsByUserIdQueryhandler(IAchievementManager achievementManager, IMapper mapper)
        {
            _achievementManager = achievementManager;
            _mapper = mapper;
        }

        public Task<List<GetUserAchievementsByUserIdVm>> Handle(GetUserAchievementsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var achievements = _achievementManager.GetUserAchievementsByUserId(request.UserId);
            var achievementsVm = _mapper.Map<List<GetUserAchievementsByUserIdVm>>(achievements);
            return Task.FromResult(achievementsVm);
        }
    }
}

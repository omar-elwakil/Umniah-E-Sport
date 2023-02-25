using AutoMapper;
using MediatR;

using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Achievements.Queries.GetAchievementById
{
    public class GetAchievementByIdQueryHandler : IRequestHandler<GetAchievementByIdQuery, GetAchievementByIdVm>
    {
        private readonly IAchievementManager _achievementManager;
        private readonly IMapper _mapper;

        public GetAchievementByIdQueryHandler(IAchievementManager achievementManager, IMapper mapper)
        {
            _achievementManager = achievementManager;
            _mapper = mapper;
        }

        public async Task<GetAchievementByIdVm> Handle(GetAchievementByIdQuery request, CancellationToken cancellationToken)
        {
            var achievement = await _achievementManager.GetAsync(request.Id);
            var achievementVm = _mapper.Map<GetAchievementByIdVm>(achievement);
            return achievementVm;
        }
    }
}

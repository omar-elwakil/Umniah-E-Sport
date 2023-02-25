using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Achievements.Commands.UpdateUserAchievement
{
    public class UpdateUserAchievementCommandHandler : IRequestHandler<UpdateUserAchievementCommand, UpdateUserAchievementVm>
    {
        private readonly IAchievementManager _achievementManager;
        private readonly IMapper _mapper;

        public UpdateUserAchievementCommandHandler(IAchievementManager achievementManager, IMapper mapper)
        {
            _achievementManager = achievementManager;
            _mapper = mapper;
        }

        public async Task<UpdateUserAchievementVm> Handle(UpdateUserAchievementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userAchievement = await _achievementManager.GetAsync(request.Id);
                _mapper.Map(request, userAchievement);
                await _achievementManager.UpdateAsync(userAchievement);
                return new UpdateUserAchievementVm { Success = true };
            }
            catch (Exception ex)
            {
                return new UpdateUserAchievementVm { Success = false, Message = ex.Message };
            }
        }
    }
}

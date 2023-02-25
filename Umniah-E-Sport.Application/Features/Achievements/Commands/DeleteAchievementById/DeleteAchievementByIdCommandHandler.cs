using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Achievements.Commands.DeleteAchievementById
{
    public class DeleteAchievementByIdCommandHandler : IRequestHandler<DeleteAchievementByIdCommand, DeleteAchievementByIdVm>
    {
        private readonly IAchievementManager _achievementManager;

        public DeleteAchievementByIdCommandHandler(IAchievementManager achievementManager)
        {
            _achievementManager = achievementManager;
        }

        public async Task<DeleteAchievementByIdVm> Handle(DeleteAchievementByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var achievement = await _achievementManager.GetAsync(request.Id);
                achievement.IsDeleted = true;
                await _achievementManager.UpdateAsync(achievement);
                return new DeleteAchievementByIdVm { Success = true };
            }
            catch (Exception ex)
            {
                return new DeleteAchievementByIdVm { Success = false, Message = ex.InnerException.Message};
            }
        }
    }
}

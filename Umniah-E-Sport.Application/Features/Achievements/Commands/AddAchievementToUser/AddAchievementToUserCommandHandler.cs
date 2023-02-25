using AutoMapper;
using MediatR;

using Umniah_E_Sport.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Achievements.Commands.AddAchievementToUser
{
    public class AddAchievementToUserCommandHandler : IRequestHandler<AddAchievementToUserCommand, AddAchievementToUserVm>
    {
        private readonly IAchievementManager _achievementManager;
        private readonly IMapper _mapper;

        public AddAchievementToUserCommandHandler(IAchievementManager achievementManager, IMapper mapper)
        {
            _achievementManager = achievementManager;
            _mapper = mapper;
        }

        public async Task<AddAchievementToUserVm> Handle(AddAchievementToUserCommand request, CancellationToken cancellationToken)
        {
            var achievement = _mapper.Map<Achievement>(request);
            try
            {
                await _achievementManager.AddAsync(achievement);
                return new AddAchievementToUserVm { Success = true };
            }
            catch (Exception ex)
            {
                return new AddAchievementToUserVm { Success = false, Message = ex.InnerException.Message };
            }
        }
    }
}

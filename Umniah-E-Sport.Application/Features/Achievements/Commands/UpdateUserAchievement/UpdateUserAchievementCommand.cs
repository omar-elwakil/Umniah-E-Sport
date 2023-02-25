using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Achievements.Commands.UpdateUserAchievement
{
    public class UpdateUserAchievementCommand : IRequest<UpdateUserAchievementVm>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string ImageName { get; set; }
    }
}

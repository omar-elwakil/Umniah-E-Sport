using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Achievements.Commands.DeleteAchievementById
{
    public class DeleteAchievementByIdCommand : IRequest<DeleteAchievementByIdVm>
    {
        public int Id { get; set; }
    }
}

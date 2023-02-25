using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Achievements.Queries.GetUserAchievementsByUserId
{
    public class GetUserAchievementsByUserIdQuery : IRequest<List<GetUserAchievementsByUserIdVm>>
    {
        public int UserId { get; set; }
    }
}

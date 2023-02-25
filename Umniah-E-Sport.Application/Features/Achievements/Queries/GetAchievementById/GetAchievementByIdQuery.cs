using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Achievements.Queries.GetAchievementById
{
    public class GetAchievementByIdQuery : IRequest<GetAchievementByIdVm>
    {
        public int Id { get; set; }
    }
}

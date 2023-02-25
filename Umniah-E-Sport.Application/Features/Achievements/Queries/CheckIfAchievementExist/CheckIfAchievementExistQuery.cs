using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Achievements.Queries.CheckIfAchievementExist
{
    public class CheckIfAchievementExistQuery : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

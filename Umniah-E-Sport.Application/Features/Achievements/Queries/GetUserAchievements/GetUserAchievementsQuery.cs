using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserAchievements
{
    public class GetUserAchievementsQuery : IRequest<List<GetUserAchievementsVm>>
    {
        public string Msisdn { get; set; }
    }
}

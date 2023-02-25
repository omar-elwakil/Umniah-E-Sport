using Umniah_E_Sport.Domain.Entities;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserMailProfile
{
    public class GetUserMailProfileVM
    {
        public string Name { get; set; }
        public string MSISDN { get; set; }
        public List<UserMailProfileTournamentsVM> UpcomingTournaments { get; set; }
        public IEnumerable<UserMailProfileGameScoreVM> LeaderBoard { get; set; }
        public IEnumerable<GetUserMailProfileAchievmentsVM> Achievements { get; set; }
    }
}
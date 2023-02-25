using Umniah_E_Sport.Domain.Entities;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileVM
    {
        public string Name { get; set; }
        public string MSISDN { get; set; }
        public List<UserProfileTournamentsVM> UpcomingTournaments { get; set; }
        public IEnumerable<UserProfileGameScoreVM> LeaderBoard { get; set; }
        public IEnumerable<UserProfileAchievmentsVM> Achievements { get; set; }
    }
}
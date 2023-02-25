using System;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentLeaderboard
{
    public class GetTournamentLeaderboardVM
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string IngameId { get; set; }
        public int Score { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}

using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentLeaderboard;
using Umniah_E_Sport.Application.Responses;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournament
{
    public class GetTournamentVM : BaseTournament
    {
        public int Capacity { get; set; }
        public int NumberOfRegistredPlayers { get; set; } // Feature => GetTournamentRegistrantsCount
        public IEnumerable<GetTournamentLeaderboardVM> UserTournaments { get; set; } // Feature => GetTournamentLeaderboard
    }
}

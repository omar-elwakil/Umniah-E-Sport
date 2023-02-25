using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentLeaderboard
{
    public class GetTournamentLeaderboardQuery : IRequest<List<GetTournamentLeaderboardVM>>
    {
        public int tournamentId { get; set; }
    }
}

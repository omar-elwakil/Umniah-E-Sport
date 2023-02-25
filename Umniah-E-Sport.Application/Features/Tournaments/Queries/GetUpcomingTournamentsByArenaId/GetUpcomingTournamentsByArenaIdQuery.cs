using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournamentsByArenaId
{
    public class GetUpcomingTournamentsByArenaIdQuery : IRequest<List<GetUpcomingTournamentsByArenaIdVM>>
    {
        public int ArenaId { get; set; }
    }
}

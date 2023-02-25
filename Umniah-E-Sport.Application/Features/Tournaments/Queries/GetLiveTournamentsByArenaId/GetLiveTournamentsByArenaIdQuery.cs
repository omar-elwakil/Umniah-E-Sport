using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetLiveTournamentsByArenaId
{
    public class GetLiveTournamentsByArenaIdQuery : IRequest<List<GetLiveTournamentsByArenaIdVM>>
    {
        public int ArenaId { get; set; }
    }
}

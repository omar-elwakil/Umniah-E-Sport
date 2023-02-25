using MediatR;
using Umniah_E_Sport.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFinishedTournamentsByArenaId
{
    public class GetFinishedTournamentsByArenaIdQuery : IRequest<IEnumerable<GetFinishedTournamentsByArenaIdVM>>
    {
        public int ArenaId { get; set; }
    }
}

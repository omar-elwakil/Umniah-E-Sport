using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByGameId
{
    public class GetTournamentsByGameIdQuery:IRequest<List<GetTournamentsByGameIdVM>>
    {
        public int GameId { get; set; }
    }
}

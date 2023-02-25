using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFinishedTournaments
{
    public class GetFinishedTournamentsQuery : IRequest<List<GetFinishedTournamentsVM>>
    {
        public string email { get; set; }
    }
}

using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetLiveTournaments
{
    public class GetLiveTournamentsQuery : IRequest<List<GetLiveTournamentsVM>>
    {
        public string email { get; set; }
    }
}

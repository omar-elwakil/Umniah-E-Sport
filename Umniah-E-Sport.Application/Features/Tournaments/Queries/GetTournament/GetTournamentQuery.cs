using MediatR;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournament
{
    public class GetTournamentQuery : IRequest<GetTournamentVM>
    {
        public int tournamentId { get; set; }
    }
}

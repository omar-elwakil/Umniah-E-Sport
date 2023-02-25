using MediatR;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentRegistrantsCount
{
    public class GetTournamentRegistrantsCountQuery : IRequest<int>
    {
        public int tournamentId { get; set; }
    }
}

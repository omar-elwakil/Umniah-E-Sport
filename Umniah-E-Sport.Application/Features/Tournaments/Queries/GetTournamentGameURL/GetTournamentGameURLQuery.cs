using MediatR;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentGameURL
{
    public class GetTournamentGameURLQuery : IRequest<GetTournamentGameURLVM>
    {
        public GetTournamentGameURLQuery() : base()
        {
        }

        public int TournamentId { get; set; }
    }
}

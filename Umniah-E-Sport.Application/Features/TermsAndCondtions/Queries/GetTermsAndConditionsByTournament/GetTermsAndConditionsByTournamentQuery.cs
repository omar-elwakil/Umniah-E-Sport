using MediatR;

namespace Umniah_E_Sport.Application.Features.TermsAndCondtions.Queries.GetTermsAndConditionsByTournament
{
    public class GetTermsAndConditionsByTournamentQuery : IRequest<GetTermsAndConditionsByTournamentVM>
    {
        public int tournamentId { get; set; }
    }
}

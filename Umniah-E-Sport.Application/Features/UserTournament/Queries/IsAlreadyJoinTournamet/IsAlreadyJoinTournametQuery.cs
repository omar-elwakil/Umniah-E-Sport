using MediatR;

namespace Umniah_E_Sport.Application.Features.UserTournament.Queries.IsAlreadyJoinTournamet
{
    public class IsAlreadyJoinTournametQuery : IRequest<IsAlreadyJoinTournametVM>
    {
        public string email { get; set; }
        public int tournamentId { get; set; }
    }
}

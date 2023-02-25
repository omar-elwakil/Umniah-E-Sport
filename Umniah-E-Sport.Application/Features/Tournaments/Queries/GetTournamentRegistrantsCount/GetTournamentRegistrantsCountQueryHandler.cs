using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentRegistrantsCount
{
    public class GetTournamentRegistrantsCountQueryHandler : IRequestHandler<GetTournamentRegistrantsCountQuery, int>
    {
        private readonly ITournamentManager _tournamentRepo;

        public GetTournamentRegistrantsCountQueryHandler(ITournamentManager tournamentRepo)
        {
            _tournamentRepo = tournamentRepo;
        }

        public Task<int> Handle(GetTournamentRegistrantsCountQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_tournamentRepo.GetTournamentRegistrantsCount(request.tournamentId));
        }
    }
}

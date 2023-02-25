using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournament
{
    public class GetTournamentQueryHandler : IRequestHandler<GetTournamentQuery, GetTournamentVM>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetTournamentQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public async Task<GetTournamentVM> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
        {
            var tournament = await _tournamentRepo.GetAsync(request.tournamentId);
            return _mapper.Map<GetTournamentVM>(tournament);
        }
    }
}

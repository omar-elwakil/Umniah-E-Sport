using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentLeaderboard
{
    public class GetTournamentLeaderboardQueryHandler : IRequestHandler<GetTournamentLeaderboardQuery, List<GetTournamentLeaderboardVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetTournamentLeaderboardQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<List<GetTournamentLeaderboardVM>> Handle(GetTournamentLeaderboardQuery request, CancellationToken cancellationToken)
        {
            var leaderBord = _tournamentRepo.GetTournamentLeaderboard(request.tournamentId);
            return Task.FromResult(_mapper.Map<List<GetTournamentLeaderboardVM>>(leaderBord));
        }
    }
}

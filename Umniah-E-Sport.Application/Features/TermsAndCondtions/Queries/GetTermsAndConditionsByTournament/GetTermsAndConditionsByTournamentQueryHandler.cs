using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.TermsAndCondtions.Queries.GetTermsAndConditionsByTournament
{
    public class GetTermsAndConditionsByTournamentQueryHandler : IRequestHandler<GetTermsAndConditionsByTournamentQuery, GetTermsAndConditionsByTournamentVM>
    {

        private readonly ITournamentManager _tournamentRepo;
        private readonly IGameManager _gameRepo;
        private readonly IMapper _mapper;

        public GetTermsAndConditionsByTournamentQueryHandler(ITournamentManager tournamentRepo, IGameManager gameRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _gameRepo = gameRepo;
            _mapper = mapper;
        }

        public async Task<GetTermsAndConditionsByTournamentVM> Handle(GetTermsAndConditionsByTournamentQuery request, CancellationToken cancellationToken)
        {
            var tournament = await _tournamentRepo.GetAsync(request.tournamentId);

            if(tournament == null)
            {
                return null;
            }

            var game = await _gameRepo.GetAsync(tournament.GameId);

            return _mapper.Map<GetTermsAndConditionsByTournamentVM>(game.TermsAndConditions);
        }
    }
}

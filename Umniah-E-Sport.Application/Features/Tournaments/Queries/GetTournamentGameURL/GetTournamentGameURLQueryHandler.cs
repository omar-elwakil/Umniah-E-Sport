using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentGameURL
{
    public class GetTournamentGameURLQueryHandler : IRequestHandler<GetTournamentGameURLQuery, GetTournamentGameURLVM>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IGameManager _gameRepo;
        private readonly IArenaManager _arenaRepo;

        public GetTournamentGameURLQueryHandler(ITournamentManager tournamentRepo, IGameManager gameRepo, IArenaManager arenaRepo)
        {
            _tournamentRepo = tournamentRepo;
            _gameRepo = gameRepo;
            _arenaRepo = arenaRepo;
        }

        public async Task<GetTournamentGameURLVM> Handle(GetTournamentGameURLQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = await _tournamentRepo.GetAsync(request.TournamentId);

                if (tournament == null)
                {
                    return new GetTournamentGameURLVM { Success = false, Message = "Tournament not found" };
                }


                if(tournament.Game == null)
                {
                    return new GetTournamentGameURLVM { Success = false, Message = "Game not found" };
                }

                var gameLink = tournament.Game?.GameLink;

                if (gameLink == null)
                {
                    return new GetTournamentGameURLVM { Success = true, GameLink = "https://bit.ly/34IJeRi" };
                }

                return new GetTournamentGameURLVM { Success = true, GameLink = gameLink };
            }
            catch (System.Exception ex)
            {

                return new GetTournamentGameURLVM { Success = false, Message = ex.Message };
            }
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetTrendingGames
{
    public class GetTrendingGamesQueryHandler : IRequestHandler<GetTrendingGamesQuery, List<GetTrendingGamesVM>>
    {
        private readonly IGameManager _gameManager;
        private readonly IMapper _mapper;

        public GetTrendingGamesQueryHandler(IGameManager gameManager, IMapper mapper)
        {
            _gameManager = gameManager;
            _mapper = mapper;
        }

        public async Task<List<GetTrendingGamesVM>> Handle(GetTrendingGamesQuery request, CancellationToken cancellationToken)
        {
            if (request.TournamentsCount == -1)
            {
                var AllGames = await _gameManager.GetAllAsync();
                return _mapper.Map<List<GetTrendingGamesVM>>(AllGames);
            }
            else
            {
                var FilteredGames = await _gameManager.GetTrendingGames(request.TournamentsCount);
                return _mapper.Map<List<GetTrendingGamesVM>>(FilteredGames);
            }
        }
    }
}

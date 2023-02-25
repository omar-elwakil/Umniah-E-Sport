using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetAllGames
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<GetAllGamesVM>>
    {
        private readonly IGameManager _gameManager;
        private readonly IMapper _mapper;

        public GetAllGamesQueryHandler(IGameManager gameManager, IMapper mapper)
        {
            _gameManager = gameManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllGamesVM>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameManager.GetAllAsync();
            return _mapper.Map<List<GetAllGamesVM>>(games);
        }
    }
}

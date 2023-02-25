using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetUserGamesByUserId
{
    public class GetUserGamesByUserIdQueryHandler : IRequestHandler<GetUserGamesByUserIdQuery, List<GetUserGamesByUserIdVm>>
    {
        private readonly IGameManager _gameManager;
        private readonly IMapper _mapper;

        public GetUserGamesByUserIdQueryHandler(IGameManager gameManager, IMapper mapper)
        {
            _gameManager = gameManager;
            _mapper = mapper;
        }

        public async Task<List<GetUserGamesByUserIdVm>> Handle(GetUserGamesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userGames = await _gameManager.GetUserGamesByUserIdAsync(request.Id);
            var UserGamesVm = _mapper.Map<List<GetUserGamesByUserIdVm>>(userGames);
            return UserGamesVm;
        }
    }
}

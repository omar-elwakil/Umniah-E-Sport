using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersGames
{
    public class GetUsersGamesQueryHandler : IRequestHandler<GetUsersGamesQuery,GetUsersGamesVM>
    {
        private readonly IUserGameManager _userGameRepo;
        private readonly IMapper _mapper;

        public GetUsersGamesQueryHandler(IUserGameManager userGameRepo, IMapper mapper)
        {
            _userGameRepo = userGameRepo;
            _mapper = mapper;
        }

        public async Task<GetUsersGamesVM> Handle(GetUsersGamesQuery request, CancellationToken cancellationToken)
        {
            var userGame = await _userGameRepo.GetUsersGames(request.GameId, request.UserId);
            return _mapper.Map<GetUsersGamesVM>(userGame);
        }
    }
}

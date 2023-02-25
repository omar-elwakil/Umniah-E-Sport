using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Users.Queries.MyLeaderBoard
{
    public class MyLeaderBoardQueryHandler : IRequestHandler<MyLeaderBoardQuery, List<MyLeaderBoardVM>>
    {
        private readonly IUserManager _userRepo;
        private readonly IGameManager _gameRepo;
        private readonly IMapper _mapper;

        public MyLeaderBoardQueryHandler(IUserManager userRepo, IGameManager gameRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _gameRepo = gameRepo;
            _mapper = mapper;
        }

        public async Task<List<MyLeaderBoardVM>> Handle(MyLeaderBoardQuery request, CancellationToken cancellationToken)
        {
            var allGames = await _gameRepo.GetAllAsync();

            var myLeaderBoardVM = new List<MyLeaderBoardVM>();

            foreach (var game in allGames)
            {
                var gameLeaderBoard = _mapper.Map<MyLeaderBoardVM>(game);
                var userGameLeadrboard = _userRepo.GetRankingUser(request.msisdn, game.Id, request.rankCount);

                gameLeaderBoard.LeaderBoardRankDTOs = _mapper.Map<List<LeaderBoardRankVM>>(userGameLeadrboard);

                myLeaderBoardVM.Add(gameLeaderBoard);
            }
            return myLeaderBoardVM;
        }
    }
}

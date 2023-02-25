using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersByGame
{
    public class GetUserByGameQueryHandler : IRequestHandler<GetUsersByGameQuery, List<GetUsersByGameVM>>
    {
        private readonly IUserGameManager _userGameRepo;
        private readonly IMapper _mapper;

        public GetUserByGameQueryHandler(IUserGameManager userGameRepo, IMapper mapper)
        {
            _userGameRepo = userGameRepo;
            _mapper = mapper;
        }

        public async Task<List<GetUsersByGameVM>> Handle(GetUsersByGameQuery request, CancellationToken cancellationToken)
        {
            var result = await _userGameRepo.GetUsersByGame(request.GameId);
            return _mapper.Map<List<GetUsersByGameVM>>(result);

        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetFeaturedCasualGames
{
    public class GetFeaturedCasualGamesQueryHandler : IRequestHandler<GetFeaturedCasualGamesQuery, List<GetFeaturedCasualGamesVm>>
    {
        private readonly ICasualGameManager _casualGameManager;
        private readonly IMapper _mapper;

        public GetFeaturedCasualGamesQueryHandler(ICasualGameManager casualGameManager, IMapper mapper)
        {
            _casualGameManager = casualGameManager;
            _mapper = mapper;
        }

        public async Task<List<GetFeaturedCasualGamesVm>> Handle(GetFeaturedCasualGamesQuery request, CancellationToken cancellationToken)
        {
            var result = await _casualGameManager.GetFeaturedCasualGame(request.Count);
            return _mapper.Map<List<GetFeaturedCasualGamesVm>>(result);
        }
    }
}

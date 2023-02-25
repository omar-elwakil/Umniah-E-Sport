using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetAllCasualGames
{
    public class GetAllCasualGamesQueryHandler : IRequestHandler<GetAllCasualGamesQuery, List<GetAllCasualGamesVm>>
    {
        private readonly ICasualGameManager _casualGameManager;
        private readonly IMapper _mapper;

        public GetAllCasualGamesQueryHandler(ICasualGameManager casualGameManager, IMapper mapper)
        {
            _casualGameManager = casualGameManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllCasualGamesVm>> Handle(GetAllCasualGamesQuery request, CancellationToken cancellationToken)
        {
            var result =await _casualGameManager.GetAllAsync();
            return _mapper.Map<List<GetAllCasualGamesVm>>(result);
        }
    }
}

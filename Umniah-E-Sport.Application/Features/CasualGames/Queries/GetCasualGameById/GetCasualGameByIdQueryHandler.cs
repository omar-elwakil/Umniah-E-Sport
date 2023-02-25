using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetCasualGameById
{
    public class GetCasualGameByIdQueryHandler : IRequestHandler<GetCasualGameByIdQuery, GetCasualGameByIdVm>
    {

        private readonly ICasualGameManager _casualGameManager;
        private readonly IMapper _mapper;

        public GetCasualGameByIdQueryHandler(ICasualGameManager casualGameManager, IMapper mapper)
        {
            _casualGameManager = casualGameManager;
            _mapper = mapper;
        }

        public async Task<GetCasualGameByIdVm> Handle(GetCasualGameByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _casualGameManager.GetAsync(request.Id);
            return _mapper.Map<GetCasualGameByIdVm>(result);
        }
    }
}

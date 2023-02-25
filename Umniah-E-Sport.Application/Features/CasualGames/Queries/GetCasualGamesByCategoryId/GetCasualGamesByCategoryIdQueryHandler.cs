using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetCasualGamesByCategoryId
{
    public class GetCasualGamesByCategoryIdQueryHandler : IRequestHandler<GetCasualGamesByCategoryIdQuery, List<GetCasualGamesByCategoryIdVm>>
    {

        private readonly ICasualGameManager _casualGameManager;
        private readonly IMapper _mapper;

        public GetCasualGamesByCategoryIdQueryHandler(ICasualGameManager casualGameManager, IMapper mapper)
        {
            _casualGameManager = casualGameManager;
            _mapper = mapper;
        }

        public async Task<List<GetCasualGamesByCategoryIdVm>> Handle(GetCasualGamesByCategoryIdQuery request, CancellationToken cancellationToken)
        {

            var result = _casualGameManager.GetCasualGameByCategoryId(request.CategoryId);
            return _mapper.Map<List<GetCasualGamesByCategoryIdVm>>(result);
        }
    }
}

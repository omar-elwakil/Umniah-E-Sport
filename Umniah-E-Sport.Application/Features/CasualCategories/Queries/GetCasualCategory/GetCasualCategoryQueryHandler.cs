using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Queries.GetCasualCategory
{
    public class GetCasualCategoryQueryHandler : IRequestHandler<GetCasualCategoryQuery, GetCasualCategoryVm>
    {
        private readonly ICasualCategoryManager _casualCategoryManager;
        private readonly IMapper _mapper;

        public GetCasualCategoryQueryHandler(ICasualCategoryManager casualCategoryManager, IMapper mapper)
        {
            _casualCategoryManager = casualCategoryManager;
            _mapper = mapper;
        }

        public async Task<GetCasualCategoryVm> Handle(GetCasualCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _casualCategoryManager.GetAsync(request.Id);
            return _mapper.Map<GetCasualCategoryVm>(result);
        }
    }
}

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Queries.GetAllCasualCategories
{
    public class GetAllCasualCategoriesQueryHandler : IRequestHandler<GetAllCasualCategoriesQuery, List<GetAllCasualCategoriesVm>>
    {
        private readonly ICasualCategoryManager _casualCategoryManager;
        private readonly IMapper _mapper;

        public GetAllCasualCategoriesQueryHandler(ICasualCategoryManager casualCategoryManager, IMapper mapper)
        {
            _casualCategoryManager = casualCategoryManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllCasualCategoriesVm>> Handle(GetAllCasualCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _casualCategoryManager.GetAllAsync();
            return _mapper.Map<List<GetAllCasualCategoriesVm>>(result);
        }
    }
}

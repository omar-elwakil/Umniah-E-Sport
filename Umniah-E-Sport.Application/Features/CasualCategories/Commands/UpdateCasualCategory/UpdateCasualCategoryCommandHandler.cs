using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Commands.UpdateCasualCategory
{
    public class UpdateCasualCategoryCommandHandler : IRequestHandler<UpdateCasualCategoryCommand, UpdateCasualCategoryResponse>
    {
        private readonly ICasualCategoryManager _casualCategoryManager;
        private readonly IMapper _mapper;

        public UpdateCasualCategoryCommandHandler(ICasualCategoryManager casualCategoryManager, IMapper mapper)
        {
            _casualCategoryManager = casualCategoryManager;
            _mapper = mapper;
        }

        public async Task<UpdateCasualCategoryResponse> Handle(UpdateCasualCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _casualCategoryManager.GetAsync(request.Id);
            if (category == null)
                return new UpdateCasualCategoryResponse { Success = false, Message = "Not found" };
            _mapper.Map(request,category);
            await _casualCategoryManager.UpdateAsync(category);
            return new UpdateCasualCategoryResponse { Success = true };
        }
    }
}

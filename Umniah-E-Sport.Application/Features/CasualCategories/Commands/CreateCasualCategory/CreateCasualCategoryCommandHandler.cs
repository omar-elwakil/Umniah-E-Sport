using AutoMapper;
using Umniah_E_Sport.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Commands.CreateCasualCategory
{
    public class CreateCasualCategoryCommandHandler : IRequestHandler<CreateCasualCategoryCommand, CreateCasualCategoryResponse>
    {
        private readonly ICasualCategoryManager _casualCategoryManager;
        private readonly IMapper _mapper;


        public CreateCasualCategoryCommandHandler(ICasualCategoryManager casualCategoryManager, IMapper mapper)
        {
            _casualCategoryManager = casualCategoryManager;
            _mapper = mapper;
        }

        public async Task<CreateCasualCategoryResponse> Handle(CreateCasualCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<CasualCategory>(request);
                if (category == null)
                    return new CreateCasualCategoryResponse { Success = false, Message = "Value can't be null" };
                await _casualCategoryManager.AddAsync(category);
                return new CreateCasualCategoryResponse { Success = true };
            }
            catch (Exception ex)
            {
                return new CreateCasualCategoryResponse { Success = false, Message = ex.Message};
            }
        }
    }
}

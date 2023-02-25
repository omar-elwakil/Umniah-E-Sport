using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.CasualCategories.Commands.DeleteCasualCategory
{
    public class DeleteCasualCategoryCommandHandler : IRequestHandler<DeleteCasualCategoryCommand, DeleteCasualCategoryResponse>
    {
        private readonly ICasualCategoryManager _casualCategoryManager;

        public DeleteCasualCategoryCommandHandler(ICasualCategoryManager casualCategoryManager)
        {
            _casualCategoryManager = casualCategoryManager;
        }

        public async Task<DeleteCasualCategoryResponse> Handle(DeleteCasualCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _casualCategoryManager.GetAsync(request.Id);
            if (category == null)
            {
                return new DeleteCasualCategoryResponse { Success = false, Message = "Not found" };
            }

            category.IsDeleted = true;
            await _casualCategoryManager.UpdateAsync(category);
            return new DeleteCasualCategoryResponse { Success = true };
        }
    }
}

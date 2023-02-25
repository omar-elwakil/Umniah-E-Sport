using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGames.Commands.DeleteCasualGame
{
    public class DeleteCasualGameCommandHandler : IRequestHandler<DeleteCasualGameCommand, DeleteCasualGameResponse>
    {

        private readonly ICasualGameManager _casualGameManager;

        public DeleteCasualGameCommandHandler(ICasualGameManager casualGameManager)
        {
            _casualGameManager = casualGameManager;
        }

        public async Task<DeleteCasualGameResponse> Handle(DeleteCasualGameCommand request, CancellationToken cancellationToken)
        {
            var category = await _casualGameManager.GetAsync(request.Id);
            if (category == null)
            {
                return new DeleteCasualGameResponse { Success = false, Message = "Not found" };
            }

            category.IsDeleted = true;
            await _casualGameManager.UpdateAsync(category);
            return new DeleteCasualGameResponse { Success = true };
        }
    }
}

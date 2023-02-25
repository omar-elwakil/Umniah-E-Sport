using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Games.Commands.DeleteGame
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, DeleteGameCommandResponse>
    {
        private readonly IGameManager _gameManager;

        public DeleteGameCommandHandler(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public async Task<DeleteGameCommandResponse> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool isDeleted = await _gameManager.DeleteGameAsync(request.id);

                return new DeleteGameCommandResponse { Success = isDeleted };
            }
            catch (System.Exception ex)
            {

                return new DeleteGameCommandResponse { Success = false, Message = ex.InnerException.Message};
            }
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Games.Commands.UpdateGame
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, UpdateGameCommandResponse>
    {
        private readonly IGameManager _gameManager;
        private readonly IMapper _mapper;

        public UpdateGameCommandHandler(IGameManager gameManager, IMapper mapper)
        {
            _gameManager = gameManager;
            _mapper = mapper;
        }

        public async Task<UpdateGameCommandResponse> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var game = await _gameManager.GetAsync(request.Id);
                if(game != null)
                {

                    _mapper.Map<UpdateGameCommand, Game>(request, game);
                    var isUpdated = await _gameManager.UpdateAsync(game);

                    if(isUpdated != null)
                    {
                        return new UpdateGameCommandResponse { Success = true };

                    }
                    return new UpdateGameCommandResponse { Success = false };
                }
                return new UpdateGameCommandResponse { Success = false, Message = "Game Not Found" };
            }
            catch (System.Exception ex)
            {

                return new UpdateGameCommandResponse { Success = false, Message =  ex.InnerException.Message};
            }
          
        }
    }
}

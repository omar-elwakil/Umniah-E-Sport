using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Games.Commands.AddGame
{
    public class AddGameCommandHandler : IRequestHandler<AddGameCommand, AddGameCommandResponse>
    {
        private readonly IGameManager _gameManager;
        private readonly IMapper _mapper;

        public AddGameCommandHandler(IGameManager gameManager, IMapper mapper)
        {
            _gameManager = gameManager;
            _mapper = mapper;
        }

        public async Task<AddGameCommandResponse> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var term = _mapper.Map<TermsAndConditions>(request);
                var game = _mapper.Map<Game>(request);

                game.TermsAndConditions = term;

                bool isAdded = await _gameManager.PostGameAsync(game);

                return new AddGameCommandResponse { Success = isAdded };
            }
            catch (Exception ex)
            {

                return new AddGameCommandResponse { Success = false, Message = ex.InnerException.Message }; ;
            }
        }
    }
}

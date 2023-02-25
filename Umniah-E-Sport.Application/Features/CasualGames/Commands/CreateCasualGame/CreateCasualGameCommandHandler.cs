using AutoMapper;
using Umniah_E_Sport.Domain.Entities;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGames.Commands.CreateCasualGame
{
    public class CreateCasualGameCommandHandler : IRequestHandler<CreateCasualGameCommand, CreateCasualGameResponse>
    {
        private readonly ICasualGameManager _casualGameManager;
        private readonly IMapper _mapper;

        public CreateCasualGameCommandHandler(ICasualGameManager casualGameManager, IMapper mapper)
        {
            _casualGameManager = casualGameManager;
            _mapper = mapper;
        }

        public async Task<CreateCasualGameResponse> Handle(CreateCasualGameCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var game = _mapper.Map<CasualGame>(request);
                if (game == null)
                    return new CreateCasualGameResponse { Success = false, Message = "Value can't be null" };
                await _casualGameManager.AddAsync(game);
                return new CreateCasualGameResponse { Success = true };
            }
            catch (Exception ex)
            {
                return new CreateCasualGameResponse { Success = false, Message = ex.Message };
            }
        }
    }
}

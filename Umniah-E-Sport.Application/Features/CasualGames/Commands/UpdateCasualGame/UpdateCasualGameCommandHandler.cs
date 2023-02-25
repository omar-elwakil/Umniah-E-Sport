using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGames.Commands.UpdateCasualGame
{
    public class UpdateCasualGameCommandHandler : IRequestHandler<UpdateCasualGameCommand, UpdateCasualGameResponse>
    {
        private readonly ICasualGameManager _casualGameManager;
        private readonly IMapper _mapper;

        public UpdateCasualGameCommandHandler(ICasualGameManager casualGameManager, IMapper mapper)
        {
            _casualGameManager = casualGameManager;
            _mapper = mapper;
        }

        public async Task<UpdateCasualGameResponse> Handle(UpdateCasualGameCommand request, CancellationToken cancellationToken)
        {

            var category = await _casualGameManager.GetAsync(request.Id);
            if (category == null)
                return new UpdateCasualGameResponse { Success = false, Message = "Not found" };
            _mapper.Map(request, category);
            await _casualGameManager.UpdateAsync(category);
            return new UpdateCasualGameResponse { Success = true };
        }
    }
}

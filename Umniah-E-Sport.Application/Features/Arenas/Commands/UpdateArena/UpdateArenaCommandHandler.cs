using AutoMapper;
using MediatR;

using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Arenas.Commands.UpdateArena
{
    public class UpdateArenaCommandHandler : IRequestHandler<UpdateArenaCommand, UpdateArenaCommandResponse>
    {
        private readonly IArenaManager _arenaManager;
        private readonly IMapper _mapper;

        public UpdateArenaCommandHandler(IArenaManager arenaManager, IMapper mapper)
        {
            _arenaManager = arenaManager;
            _mapper = mapper;
        }

        public async Task<UpdateArenaCommandResponse> Handle(UpdateArenaCommand request, CancellationToken cancellationToken)
        {
            UpdateArenaCommandResponse response = new UpdateArenaCommandResponse();
            var arena = await _arenaManager.GetAsync(request.Id);
            if (arena != null)
            {
                _mapper.Map<UpdateArenaCommand, Arena>(request, arena);
                await _arenaManager.UpdateAsync(arena);

                response.Success = true;
                return response;
            }
            else
            {
                response.Success = false;
                return response;
            }
        }
    }
}

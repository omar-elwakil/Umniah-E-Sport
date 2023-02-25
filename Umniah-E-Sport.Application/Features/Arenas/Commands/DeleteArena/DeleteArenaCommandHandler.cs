using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Arenas.Commands.DeleteArena
{
    public class DeleteArenaCommandHandler : IRequestHandler<DeleteArenaCommand, DeleteArenaCommandResponse>
    {
        private readonly IArenaManager _arenaManager;

        public DeleteArenaCommandHandler(IArenaManager arenaManager)
        {
            _arenaManager = arenaManager;
        }

        public async Task<DeleteArenaCommandResponse> Handle(DeleteArenaCommand request, CancellationToken cancellationToken)
        {
            DeleteArenaCommandResponse response = new DeleteArenaCommandResponse();
            var arena = await _arenaManager.GetAsync(request.ArenaId);
            if (arena != null)
            {
                arena.IsDeleted = true;
                await _arenaManager.UpdateAsync(arena);
                response.Success = true;
                return response;
            }
            response.Success = false;
            response.Message = "Not Found";
            return response;
        }
    }
}

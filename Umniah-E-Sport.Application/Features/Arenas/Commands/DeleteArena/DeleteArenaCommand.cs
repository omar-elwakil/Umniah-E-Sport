using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Arenas.Commands.DeleteArena
{
    public class DeleteArenaCommand : IRequest<DeleteArenaCommandResponse>
    {
        public int ArenaId { get; set; }
    }
}

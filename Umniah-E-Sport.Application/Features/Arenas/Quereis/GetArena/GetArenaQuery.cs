using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Arenas.Quereis.GetArena
{
    public class GetArenaQuery : IRequest<GetArenaVM>
    {
        public int ArenaId { get; set; }
    }
}

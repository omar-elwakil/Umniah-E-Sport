using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Arenas.Quereis.GetArena
{
    public class GetArenaQueryHandler : IRequestHandler<GetArenaQuery, GetArenaVM>
    {
        private readonly IArenaManager _arenaManager;
        private readonly IMapper _mapper;

        public GetArenaQueryHandler(IArenaManager arenaManager, IMapper mapper)
        {
            _arenaManager = arenaManager;
            _mapper = mapper;
        }

        public async Task<GetArenaVM> Handle(GetArenaQuery request, CancellationToken cancellationToken)
        {
            var result = await _arenaManager.GetAsync(request.ArenaId);

            return _mapper.Map<GetArenaVM>(result);
        }
    }
}

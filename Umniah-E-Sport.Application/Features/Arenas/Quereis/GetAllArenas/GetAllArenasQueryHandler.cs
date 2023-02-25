using AutoMapper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Contracts.Persistence;

namespace Umniah_E_Sport.Application.Features.Arenas.Quereis.GetAllArenas
{
    public class GetAllArenasQueryHandler : IRequestHandler<GetAllArenasQuery, List<ArenaCardVM>>
    {
        private readonly IArenaManager _arenaManager;
        private readonly IMapper _mapper;

        public GetAllArenasQueryHandler(IArenaManager arenaManager, IMapper mapper)
        {
            _arenaManager = arenaManager;
            _mapper = mapper;
        }

        public async Task<List<ArenaCardVM>> Handle(GetAllArenasQuery request, CancellationToken cancellationToken)
        {
            var Arenas = await _arenaManager.GetAllAsync();
            return _mapper.Map<List<ArenaCardVM>>(Arenas);
        }
    }
}

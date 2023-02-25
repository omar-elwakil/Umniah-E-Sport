using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetLiveTournamentsByArenaId
{
    public class GetLiveTournamentsByArenaIdQueryHandler : IRequestHandler<GetLiveTournamentsByArenaIdQuery, List<GetLiveTournamentsByArenaIdVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetLiveTournamentsByArenaIdQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<List<GetLiveTournamentsByArenaIdVM>> Handle(GetLiveTournamentsByArenaIdQuery request, CancellationToken cancellationToken)
        {
            var LiveTournaments = _tournamentRepo.GetLiveTournamentsByArenaId(request.ArenaId);
            if (LiveTournaments == null) return null;
            return Task.FromResult(_mapper.Map<List<GetLiveTournamentsByArenaIdVM>>(LiveTournaments));
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournamentsByArenaId
{
    public class GetUpcomingTournamentsByArenaIdQueryHandler : IRequestHandler<GetUpcomingTournamentsByArenaIdQuery, List<GetUpcomingTournamentsByArenaIdVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetUpcomingTournamentsByArenaIdQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<List<GetUpcomingTournamentsByArenaIdVM>> Handle(GetUpcomingTournamentsByArenaIdQuery request, CancellationToken cancellationToken)
        {
            var upcomingTournaments = _tournamentRepo.GetUpcomingTournamentsByArenaId(request.ArenaId);
            if (upcomingTournaments == null) return null;
            return Task.FromResult(_mapper.Map<List<GetUpcomingTournamentsByArenaIdVM>>(upcomingTournaments));
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFinishedTournamentsByArenaId
{
    public class GetFinishedTournamentsByArenaIdQueryHandler : IRequestHandler<GetFinishedTournamentsByArenaIdQuery, IEnumerable<GetFinishedTournamentsByArenaIdVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetFinishedTournamentsByArenaIdQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetFinishedTournamentsByArenaIdVM>> Handle(GetFinishedTournamentsByArenaIdQuery request, CancellationToken cancellationToken)
        {
            var finishedTournaments = _tournamentRepo.GetFinishedTournamentsByArenaId(request.ArenaId);
            if (finishedTournaments == null) return null;
            return Task.FromResult(_mapper.Map<IEnumerable<GetFinishedTournamentsByArenaIdVM>>(finishedTournaments));
        }
    }
}

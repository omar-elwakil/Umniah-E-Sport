using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByGameId
{
    public class GetTournamentsByGameIdQueryHandler : IRequestHandler<GetTournamentsByGameIdQuery, List<GetTournamentsByGameIdVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        public readonly IMapper _mapper;

        public GetTournamentsByGameIdQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<List<GetTournamentsByGameIdVM>> Handle(GetTournamentsByGameIdQuery request, CancellationToken cancellationToken)
        {
            var tournamentsByGameId = _tournamentRepo.GetTournamentsByGame(request.GameId);
            if (tournamentsByGameId == null) return null;
            return Task.FromResult(_mapper.Map<List<GetTournamentsByGameIdVM>>(tournamentsByGameId));
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetLiveTournaments
{
    public class GetLiveTournamentsQueryHandler : IRequestHandler<GetLiveTournamentsQuery, List<GetLiveTournamentsVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetLiveTournamentsQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<List<GetLiveTournamentsVM>> Handle(GetLiveTournamentsQuery request, CancellationToken cancellationToken)
        {
            var liveTournaments = _tournamentRepo.GetLiveTournamentsByUser(request.email);
            return Task.FromResult(_mapper.Map<List<GetLiveTournamentsVM>>(liveTournaments));
        }
    }
}

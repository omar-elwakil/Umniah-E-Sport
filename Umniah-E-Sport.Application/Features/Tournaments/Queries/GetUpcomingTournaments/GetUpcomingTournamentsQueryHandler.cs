using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournaments
{
    public class GetUpcomingTournamentsQueryHandler : IRequestHandler<GetUpcomingTournamentsQuery, List<GetUpcomingTournamentsVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetUpcomingTournamentsQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<List<GetUpcomingTournamentsVM>> Handle(GetUpcomingTournamentsQuery request, CancellationToken cancellationToken)
        {
            var result = _tournamentRepo.GetUpcomingTournamentsByUser(request.EMAIL);

            return Task.FromResult(_mapper.Map<List<GetUpcomingTournamentsVM>>(result));
        }
    }
}

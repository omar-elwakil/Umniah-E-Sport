using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFinishedTournaments
{
    public class GetFinishedTournamentsQueryHandler : IRequestHandler<GetFinishedTournamentsQuery, List<GetFinishedTournamentsVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetFinishedTournamentsQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<List<GetFinishedTournamentsVM>> Handle(GetFinishedTournamentsQuery request, CancellationToken cancellationToken)
        {
            var finishedTournaments = _tournamentRepo.GetFinishedTournamentsByUser(request.email);
            return Task.FromResult(_mapper.Map<List<GetFinishedTournamentsVM>>(finishedTournaments));
        }
    }
}

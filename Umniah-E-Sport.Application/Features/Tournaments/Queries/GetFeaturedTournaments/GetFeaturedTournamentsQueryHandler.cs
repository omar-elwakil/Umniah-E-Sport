using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFeaturedTournaments
{
    public class GetFeaturedTournamentsQueryHandler : IRequestHandler<GetFeaturedTournamentsQuery, List<GetFeaturedTournamentsVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetFeaturedTournamentsQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public Task<List<GetFeaturedTournamentsVM>> Handle(GetFeaturedTournamentsQuery request, CancellationToken cancellationToken)
        {
            var featureTournament = _tournamentRepo.GetFeaturedTournaments();
            return Task.FromResult(_mapper.Map<List<GetFeaturedTournamentsVM>>(featureTournament));
        }
    }
}

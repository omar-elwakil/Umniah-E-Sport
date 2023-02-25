using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetAllTournamets
{
    public class GetAllTournamentsQueryHandler : IRequestHandler<GetAllTournamentsQuery, List<GetAllTournamentsVM>>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public GetAllTournamentsQueryHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public async Task<List<GetAllTournamentsVM>> Handle(GetAllTournamentsQuery request, CancellationToken cancellationToken)
        {
            var model = await _tournamentRepo.GetAllAsync();
            return _mapper.Map<List<GetAllTournamentsVM>>(model);
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.TournamentTypeFeature.GetAllTournamentTypes
{
    public class GetAllTournamentTypesQueryHandler : IRequestHandler<GetAllTournamentTypesQuery, List<GetAllTournamentTypesVM>>
    {
        private readonly ITournamentTypeManager _tournamentTypeRepo;
        private readonly IMapper _mapper;

        public GetAllTournamentTypesQueryHandler(ITournamentTypeManager tournamentTypeRepo, IMapper mapper)
        {
            _tournamentTypeRepo = tournamentTypeRepo;
            _mapper = mapper;
        }

        public async Task<List<GetAllTournamentTypesVM>> Handle(GetAllTournamentTypesQuery request, CancellationToken cancellationToken)
        {
            var tournamentTypes = await _tournamentTypeRepo.GetAllAsync();
            return _mapper.Map<List<GetAllTournamentTypesVM>>(tournamentTypes);
        }
    }
}

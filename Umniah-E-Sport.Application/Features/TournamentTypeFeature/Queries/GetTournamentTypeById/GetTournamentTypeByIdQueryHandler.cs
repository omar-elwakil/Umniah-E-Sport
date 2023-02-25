using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.TournamentTypeFeature.Queries.GetTournamentTypeById
{
    public class GetTournamentTypeByIdQueryHandler : IRequestHandler<GetTournamentTypeByIdQuery, GetTournamentTypeByIdVm>
    {
        private readonly ITournamentTypeManager _tournamentTypeRepo;
        private readonly IMapper _mapper;

        public GetTournamentTypeByIdQueryHandler(ITournamentTypeManager tournamentTypeRepo, IMapper mapper)
        {
            _tournamentTypeRepo = tournamentTypeRepo;
            _mapper = mapper;
        }

        public async Task<GetTournamentTypeByIdVm> Handle(GetTournamentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var tournamentType = await _tournamentTypeRepo.GetAsync(request.Id);
            if (tournamentType == null)
            {
                return new GetTournamentTypeByIdVm { Success = false , Message = "Tournament Type not found"};
            }
            var getTournamentTypeByIdvm = _mapper.Map<GetTournamentTypeByIdVm>(tournamentType);
            getTournamentTypeByIdvm.Success = true;
            return getTournamentTypeByIdvm;
        }
    }
}

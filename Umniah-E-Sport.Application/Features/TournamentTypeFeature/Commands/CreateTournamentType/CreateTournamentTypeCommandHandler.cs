using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.CreateTournamentType
{
    public class CreateTournamentTypeCommandHandler : IRequestHandler<CreateTournamentTypeCommand, CreateTournamentTypeCommandResponse>
    {
        private readonly ITournamentTypeManager _TournamentTypeRepo;
        private readonly IMapper _mapper;

        public CreateTournamentTypeCommandHandler(ITournamentTypeManager tournamentTypeRepo, IMapper mapper)
        {
            _TournamentTypeRepo = tournamentTypeRepo;
            _mapper = mapper;
        }

        public async Task<CreateTournamentTypeCommandResponse> Handle(CreateTournamentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var tournamentType = _mapper.Map<TournamentType>(request);
                if (tournamentType == null) return new CreateTournamentTypeCommandResponse { Message = "Failed", Success = false };

                await _TournamentTypeRepo.AddAsync(tournamentType);
                return new CreateTournamentTypeCommandResponse { Success = true };
            }
            catch (Exception ex)
            {
                return new CreateTournamentTypeCommandResponse { Message = ex.Message, Success = false };
            }

        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Commands.CreateTournament
{
    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, CreateTournamentCommandResponse>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public CreateTournamentCommandHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public async Task<CreateTournamentCommandResponse> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = _mapper.Map<Tournament>(request);
                if (tournament != null)
                {
                    await _tournamentRepo.AddAsync(tournament);
                    return new CreateTournamentCommandResponse { Success = true };
                }
                return new CreateTournamentCommandResponse { Success = false, Message = "Failed to Add" };
            }
            catch (Exception ex)
            {
                return new CreateTournamentCommandResponse { Success = false, Message = ex.Message };
            }

        }
    }
}

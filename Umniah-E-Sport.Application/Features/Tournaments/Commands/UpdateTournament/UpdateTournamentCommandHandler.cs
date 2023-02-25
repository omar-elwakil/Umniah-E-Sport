using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Commands.UpdateTournament
{
    public class UpdateTournamentCommandHandler : IRequestHandler<UpdateTournamentCommand, UpdateTournamentCommandResponse>
    {
        private readonly ITournamentManager _tournamentRepo;
        private readonly IMapper _mapper;

        public UpdateTournamentCommandHandler(ITournamentManager tournamentRepo, IMapper mapper)
        {
            _tournamentRepo = tournamentRepo;
            _mapper = mapper;
        }

        public async Task<UpdateTournamentCommandResponse> Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var tournament = await _tournamentRepo.GetAsync(request.Id);
                if (tournament != null)
                {
                    _mapper.Map<UpdateTournamentCommand, Tournament>(request, tournament);
                    if (tournament != null)
                    {
                        await _tournamentRepo.UpdateAsync(tournament);
                        return new UpdateTournamentCommandResponse { Success = true };
                    }
                }
                return new UpdateTournamentCommandResponse { Success = false, Message = "Not Found" };
            }
            catch (Exception ex)
            {
                return new UpdateTournamentCommandResponse { Success = false, Message = ex.Message };
            }
        }
    }
}


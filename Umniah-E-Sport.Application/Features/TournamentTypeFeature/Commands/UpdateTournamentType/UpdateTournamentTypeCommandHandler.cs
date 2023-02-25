using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.UpdateTournamentType
{
    public class UpdateTournamentTypeCommandHandler : IRequestHandler<UpdateTournamentTypeCommand, UpdateTournamentTypeCommandResponse>
    {
        private readonly ITournamentTypeManager _tournamentTypeRepo;
        private readonly IMapper _mapper;

        public UpdateTournamentTypeCommandHandler(ITournamentTypeManager tournamentTypeRepo, IMapper mapper)
        {
            _tournamentTypeRepo = tournamentTypeRepo;
            _mapper = mapper;
        }

        public async Task<UpdateTournamentTypeCommandResponse> Handle(UpdateTournamentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var tournament = await _tournamentTypeRepo.GetAsync(request.Id);
                _mapper.Map<UpdateTournamentTypeCommand, TournamentType>(request, tournament);
                if (tournament != null)
                {
                    await _tournamentTypeRepo.UpdateAsync(tournament);

                    return new UpdateTournamentTypeCommandResponse { Success = true };
                }
                return new UpdateTournamentTypeCommandResponse { Success = false, Message = "Not Found" };
            }
            catch (Exception ex)
            {
                return new UpdateTournamentTypeCommandResponse { Success = false, Message = ex.Message };
            }
        }
    }
}

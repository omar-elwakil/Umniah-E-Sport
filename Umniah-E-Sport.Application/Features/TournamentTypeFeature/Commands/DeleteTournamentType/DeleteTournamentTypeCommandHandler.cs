using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.DeleteTournamentType
{
    public class DeleteTournamentTypeCommandHandler : IRequestHandler<DeleteTournamentTypeCommand, DeleteTournamentTypeCommandResponse>
    {
        private readonly ITournamentTypeManager _tournamentTypeRepo;
        private readonly IMapper _mapper;

        public DeleteTournamentTypeCommandHandler(ITournamentTypeManager tournamentTypeRepo, IMapper mapper)
        {
            _tournamentTypeRepo = tournamentTypeRepo;
            _mapper = mapper;
        }

        public async Task<DeleteTournamentTypeCommandResponse> Handle(DeleteTournamentTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var tournamentType = await _tournamentTypeRepo.GetAsync(request.Id);
                if (tournamentType != null)
                {
                    tournamentType.IsDeleted = true;
                    await _tournamentTypeRepo.UpdateAsync(tournamentType);
                    return new DeleteTournamentTypeCommandResponse { Success = true };
                }
                return new DeleteTournamentTypeCommandResponse { Success = false, Message = "Not Found" };
            }
            catch (Exception ex)
            {
                return new DeleteTournamentTypeCommandResponse { Success = false, Message = ex.Message };
            }
        }
    }
}

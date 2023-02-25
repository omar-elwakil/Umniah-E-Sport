using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Tournaments.Commands.DeleteTournament
{
    public class DeleteTournamentCommandHandler : IRequestHandler<DeleteTournamentCommand, DeleteTournamentCommandResponse>
    {
        private readonly ITournamentManager _tournamentRepo;

        public DeleteTournamentCommandHandler(ITournamentManager tournamentRepo)
        {
            _tournamentRepo = tournamentRepo;
        }

        public async Task<DeleteTournamentCommandResponse> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var tournament = await _tournamentRepo.GetAsync(request.TournamentId);
                if (tournament != null)
                {
                    tournament.IsDeleted = true;
                    await _tournamentRepo.UpdateAsync(tournament);
                    return new DeleteTournamentCommandResponse { Success = true };
                }
                return new DeleteTournamentCommandResponse { Success = false, Message = "Not Found" };
            }
            catch (Exception ex)
            {
                return new DeleteTournamentCommandResponse { Success = false, Message = ex.Message };
            }
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Commands.DeleteTournament
{
    public class DeleteTournamentCommand : IRequest<DeleteTournamentCommandResponse>
    {
        public int TournamentId { get; set; }
    }
}

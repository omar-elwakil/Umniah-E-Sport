using MediatR;
using Umniah_E_Sport.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Commands.CreateTournament
{
    public class CreateTournamentCommand : BaseTournament,IRequest<CreateTournamentCommandResponse>
    {
        public DateTime CreationTimeStamp { get; set; }
    }
}

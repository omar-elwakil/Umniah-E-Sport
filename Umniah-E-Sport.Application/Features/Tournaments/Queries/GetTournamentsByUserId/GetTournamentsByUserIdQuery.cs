using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByUserId
{
    public class GetTournamentsByUserIdQuery : IRequest<List<GetTournamentsByUserIdVm>>
    {
        public int UserId { get; set; }
    }
}

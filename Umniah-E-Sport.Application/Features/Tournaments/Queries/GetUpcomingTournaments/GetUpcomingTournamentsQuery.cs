using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournaments
{
    public class GetUpcomingTournamentsQuery : IRequest<List<GetUpcomingTournamentsVM>>
    {
        public string EMAIL { get; set; }
    }
}

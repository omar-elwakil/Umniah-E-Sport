using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetAllTournamets
{
    public class GetAllTournamentsQuery : IRequest<List<GetAllTournamentsVM>>
    {
    }
}

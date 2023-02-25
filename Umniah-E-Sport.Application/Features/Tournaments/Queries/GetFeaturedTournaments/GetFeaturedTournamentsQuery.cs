using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFeaturedTournaments
{
    public class GetFeaturedTournamentsQuery : IRequest<List<GetFeaturedTournamentsVM>>
    {
    }
}

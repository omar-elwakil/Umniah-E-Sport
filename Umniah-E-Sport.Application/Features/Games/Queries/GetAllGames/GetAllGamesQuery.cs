using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetAllGames
{
    public class GetAllGamesQuery : IRequest<List<GetAllGamesVM>>
    {
    }
}

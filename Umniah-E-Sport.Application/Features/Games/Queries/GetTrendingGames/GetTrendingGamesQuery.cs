using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetTrendingGames
{
    public class GetTrendingGamesQuery : IRequest<List<GetTrendingGamesVM>>
    {
        public int TournamentsCount { get; set; }
    }
}

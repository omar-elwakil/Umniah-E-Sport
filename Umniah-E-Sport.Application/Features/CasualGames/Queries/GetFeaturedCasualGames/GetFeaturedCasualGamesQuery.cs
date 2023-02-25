using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetFeaturedCasualGames
{
    public class GetFeaturedCasualGamesQuery : IRequest<List<GetFeaturedCasualGamesVm>>
    {
        public int Count { get; set; }
    }
}

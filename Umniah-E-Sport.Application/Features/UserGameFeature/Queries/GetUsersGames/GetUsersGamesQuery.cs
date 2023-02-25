using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersGames
{
    public class GetUsersGamesQuery : IRequest<GetUsersGamesVM>
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
    }
}

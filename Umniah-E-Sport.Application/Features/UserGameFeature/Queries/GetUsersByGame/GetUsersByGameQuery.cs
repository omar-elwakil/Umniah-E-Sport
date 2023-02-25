using MediatR;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersByGame
{
    public class GetUsersByGameQuery : IRequest<List<GetUsersByGameVM>>
    {
        public int GameId { get; set; }
    }
}

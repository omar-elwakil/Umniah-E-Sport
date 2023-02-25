using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Users.Queries.MyLeaderBoard
{
    public class MyLeaderBoardQuery : IRequest<List<MyLeaderBoardVM>>
    {
        public string msisdn { get; set; }
        public int rankCount { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Users.Queries.GetLeaderBoard
{
    public class GetLeaderBoardQuery : IRequest<List<GetLeaderBoardVM>>
    {
    }
}

/*using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Users.Queries.GetLeaderBoard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaderBoardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-leaderboard")]
        public async Task<ActionResult<List<GetLeaderBoardVM>>> GetLeaderBoard()
        {
            return await _mediator.Send(new GetLeaderBoardQuery());
        }
    }
}
*/
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Games.Queries.GetUserGamesByUserId;
using Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersByGame;
using Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersGames;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserGameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-users-by-game")]
        public async Task<ActionResult<List<GetUsersByGameVM>>> GetUsersByGame([FromQuery]GetUsersByGameQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("get-users-games")]
        public async Task<ActionResult<GetUsersGamesVM>> GetUsersGames ([FromQuery]GetUsersGamesQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("get-user-games-by-userId")]
        public async Task<ActionResult<List<GetUserGamesByUserIdVm>>> GetUserGamesById ([FromQuery]GetUserGamesByUserIdQuery getUserGamesByUserIdQuery)
        {
            return await _mediator.Send(getUserGamesByUserIdQuery);
        }
    }
}

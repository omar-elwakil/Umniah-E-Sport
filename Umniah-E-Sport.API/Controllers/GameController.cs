using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Games.Commands.AddGame;
using Umniah_E_Sport.Application.Features.Games.Commands.DeleteGame;
using Umniah_E_Sport.Application.Features.Games.Commands.UpdateGame;
using Umniah_E_Sport.Application.Features.Games.Queries.GetAllGames;
using Umniah_E_Sport.Application.Features.Games.Queries.GetGame;
using Umniah_E_Sport.Application.Features.Games.Queries.GetTrendingGames;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-games")]
        public async Task<ActionResult<List<GetAllGamesVM>>> GetAllGames()
        {
            var response = await _mediator.Send(new GetAllGamesQuery());

            return Ok(response);
        }

        [HttpGet("get-trending-games")]
        public async Task<ActionResult<List<GetTrendingGamesVM>>> GetTrendingGames([FromQuery] GetTrendingGamesQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("get-game")]
        public async Task<ActionResult<GetGameVM>> GetGame([FromQuery] GetGameQuery query)
        {
         
            var response = await _mediator.Send(query);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }else if (!response.IsExist)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("add-game")]
        public async Task<ActionResult<AddGameCommandResponse>> PostGame([FromBody] AddGameCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("edit-game")]
        public async Task<ActionResult<UpdateGameCommandResponse>> EditGame([FromBody] UpdateGameCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("delete-game")]
        public async Task<ActionResult<DeleteGameCommandResponse>> DeleteGame([FromBody] DeleteGameCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
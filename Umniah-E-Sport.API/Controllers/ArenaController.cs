using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Arenas.Commands.CreateArena;
using Umniah_E_Sport.Application.Features.Arenas.Commands.DeleteArena;
using Umniah_E_Sport.Application.Features.Arenas.Commands.UpdateArena;
using Umniah_E_Sport.Application.Features.Arenas.Quereis.GetAllArenas;
using Umniah_E_Sport.Application.Features.Arenas.Quereis.GetArena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArenaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-arenas")]
        public async Task<ActionResult<List<ArenaCardVM>>> GetAllArenasAsync()
        {
            var arenas = await _mediator.Send(new GetAllArenasQuery());
            return Ok(arenas);
        }

        [HttpGet("get-arena")]
        public async Task<ActionResult<GetArenaVM>> GetArenasAsync([FromQuery] GetArenaQuery getArenaQuery)
        {
            return await _mediator.Send(getArenaQuery);
        }

        [HttpPost("create-arena")]
        public async Task<ActionResult<CreateArenaCommandResponse>> CreateArenaAsync([FromBody] CreateArenaCommand createArenaCommand)
        {
            return await _mediator.Send(createArenaCommand);
        }

        [HttpDelete("delete-arena")]
        public async Task<ActionResult<DeleteArenaCommandResponse>> DeleteArenaAsync([FromBody] DeleteArenaCommand deleteArenaCommand)
        {
            return await _mediator.Send(deleteArenaCommand);
        }

        [HttpPut("update-arena")]
        public async Task<ActionResult<UpdateArenaCommandResponse>> UpdateArenaAsync([FromBody] UpdateArenaCommand updateArenaCommand)
        {
            return await _mediator.Send(updateArenaCommand);
        }
    }
}

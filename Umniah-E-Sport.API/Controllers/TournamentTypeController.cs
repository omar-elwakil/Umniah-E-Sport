using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.CreateTournamentType;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.DeleteTournamentType;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.UpdateTournamentType;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.GetAllTournamentTypes;
using Umniah_E_Sport.Application.Features.TournamentTypeFeature.Queries.GetTournamentTypeById;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentTypeController : ControllerBase
    {
        IMediator _mediator;

        public TournamentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-tournament-types")]
        public async Task<ActionResult<List<GetAllTournamentTypesVM>>> GetAllTournamentTypes()
        {
            return await _mediator.Send(new GetAllTournamentTypesQuery());
        }
        [HttpGet("get-tournament-type-by-id")]
        public async Task<ActionResult<GetTournamentTypeByIdVm>> GetTournamentTypeById([FromQuery]GetTournamentTypeByIdQuery getTournamentTypeByIdQuery)
        {
            return await _mediator.Send(getTournamentTypeByIdQuery);
        }

        [HttpPost("create-tournament-type")]
        public async Task<ActionResult<CreateTournamentTypeCommandResponse>> CreateTournamentType(CreateTournamentTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("update-tournament-type")]
        public async Task<ActionResult<UpdateTournamentTypeCommandResponse>> UpdateTournamentType(UpdateTournamentTypeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("delete-tournament-type")]
        public async Task<ActionResult<DeleteTournamentTypeCommandResponse>> DeleteTournamentType(DeleteTournamentTypeCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}

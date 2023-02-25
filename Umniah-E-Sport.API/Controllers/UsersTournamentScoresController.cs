using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.UserTournament.Commands.AddUsersScores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersTournamentScoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersTournamentScoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-users-tournament-scores")]
        public async Task<AddUsersScoresCommandResponse> GetOtp([FromBody] AddUsersScoresCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }
    }
}
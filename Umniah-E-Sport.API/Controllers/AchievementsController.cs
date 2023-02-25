using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Achievements.Commands.AddAchievementToUser;
using Umniah_E_Sport.Application.Features.Achievements.Commands.DeleteAchievementById;
using Umniah_E_Sport.Application.Features.Achievements.Commands.UpdateUserAchievement;
using Umniah_E_Sport.Application.Features.Achievements.Queries.CheckIfAchievementExist;
using Umniah_E_Sport.Application.Features.Achievements.Queries.GetAchievementById;
using Umniah_E_Sport.Application.Features.Achievements.Queries.GetUserAchievementsByUserId;

using System.Collections.Generic;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Features.Users.Queries.GetUserAchievements;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AchievementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-achievement-by-id")]
        public async Task<ActionResult<GetAchievementByIdVm>> GetAchievementById([FromQuery] GetAchievementByIdQuery getAchievementByIdQuery)
        {
            var achievement = await _mediator.Send(getAchievementByIdQuery);
            if (achievement == null)
            {
                return NotFound();
            }
            return Ok(achievement);
        }
        [HttpGet("check-if-achievement-exist")]
        public async Task<ActionResult<bool>> CheckIfAchievementExist([FromQuery] CheckIfAchievementExistQuery checkIfAchievementExistQuery)
        {
            var isExist = await _mediator.Send(checkIfAchievementExistQuery);
            return Ok(isExist);
        }
        [HttpPost("add-achievement-to-user")]
        public async Task<ActionResult<AddAchievementToUserVm>> AddAchievementToUser([FromBody] AddAchievementToUserCommand addAchievementToUserCommand)
        {
            var response = await _mediator.Send(addAchievementToUserCommand);
            if (response.Success)
            {
                return Ok();
            }
            return BadRequest(response);
        }
        [HttpDelete("delete-achievement-by-id")]
        public async Task<ActionResult<DeleteAchievementByIdVm>> DeleteAchievementById([FromQuery] DeleteAchievementByIdCommand deleteAchievementByIdCommand)
        {
            var response = await _mediator.Send(deleteAchievementByIdCommand);
            if (response.Success)
            {
                return Ok();
            }
            return BadRequest(response);
        }
        [HttpGet("get-user-achievements-by-msisdn")]
        public async Task<ActionResult<List<GetUserAchievementsVm>>> GetUserAchievements([FromQuery] GetUserAchievementsQuery getUserAchievementsQuery)
        {
            var response = await _mediator.Send(getUserAchievementsQuery);
            return Ok(response);
        }
        [HttpGet("get-user-achievements-by-user-id")]
        public async Task<ActionResult<List<GetUserAchievementsByUserIdVm>>> GetUserAchievementsByUserId([FromQuery] GetUserAchievementsByUserIdQuery getUserAchievementsByUserIdQuery)
        {
            var response = await _mediator.Send(getUserAchievementsByUserIdQuery);
            return Ok(response);
        }
       [HttpPut("update-user-achievements")]
        public async Task<ActionResult<UpdateUserAchievementVm>> UpdateUserAchievements([FromQuery] UpdateUserAchievementCommand updateUserAchievementCommand)
        {
            var response = await _mediator.Send(updateUserAchievementCommand);
            return Ok(response);
        }
    }
}

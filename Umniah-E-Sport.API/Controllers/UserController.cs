using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Users.Commands.RegisteredUserTournments;
using Umniah_E_Sport.Application.Features.Users.Commands.UpdateUserProfile;
using Umniah_E_Sport.Application.Features.Users.Queries.GetAllUsersOrderedByScore;
using Umniah_E_Sport.Application.Features.Users.Queries.GetUserProfile;
using Umniah_E_Sport.Application.Features.Users.Queries.GetUsersWithKeywordOrderedByScore;
using Umniah_E_Sport.Application.Features.Users.Queries.IsUserAbleToSeeContent;
using Umniah_E_Sport.Application.Features.Users.Queries.MyLeaderBoard;
using Umniah_E_Sport.Application.Features.UserTournament.Queries.IsAlreadyJoinTournamet;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umniah_E_Sport.Application.Features.Users.Queries.GetUserMailProfile;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("update-user-name")]
        public async Task<UpdateUserProfileCommandResponse> UpdaetUserProfile([FromBody] UpdateUserProfileCommand updateUserProfileCommand)
        {
            var response = await _mediator.Send(updateUserProfileCommand);

            return response;
        }

        [HttpGet("is-user-able-to-see-content")]
        public async Task<bool> IsUserAbleToSeeContent([FromQuery] IsUserAbleToSeeContentQuery query)
        {
            return await _mediator.Send(query);
        }


        [HttpPost("join-user-tournament")]
        public async Task<RegisteredUserTournmentsCommandResponse> JoinUserTournament([FromBody] RegisteredUserTournmentsCommand registeredUserTournmentsCommand)
        {
            var response = await _mediator.Send(registeredUserTournmentsCommand);

            return response;
        }

        [HttpGet("get-user-profile")]
        public async Task<ActionResult<GetUserProfileVM>> GetUserProfile([FromQuery] GetUserProfileQuery getUserProfileQuery)
        {
            var UserProfile = await _mediator.Send(getUserProfileQuery);
            if (UserProfile == null) { return NotFound(); }
            //if (UserProfile.MSISDN == null || UserProfile.MSISDN == "") { return NotFound(); }
            return Ok(UserProfile);
        }

        [HttpGet("get-user-mail")]
        public async Task<ActionResult<GetUserMailProfileVM>> GetUserMailProfile([FromQuery] GetUserMailProfileQuery getUserMailProfileQuery)
        {
            var UserProfile = await _mediator.Send(getUserMailProfileQuery);
            if (UserProfile == null) { return NotFound(); }
            //if (UserProfile.MSISDN == null || UserProfile.MSISDN == "") { return NotFound(); }
            return Ok(UserProfile);
        }

        [HttpGet("ranking-leader-boards")]
        public async Task<ActionResult<List<MyLeaderBoardVM>>> GetRankingLeaderBoards([FromQuery] MyLeaderBoardQuery myLeaderBoardQuery)
        {
            var response = await _mediator.Send(myLeaderBoardQuery);

            return Ok(response);
        }


        [HttpGet("is-user-already-join-tournament")]
        public async Task<ActionResult<IsAlreadyJoinTournametVM>> IsAlreadyJoinTourname([FromQuery] IsAlreadyJoinTournametQuery isAlreadyJoinTournametQuery)
        {
            var response = await _mediator.Send(isAlreadyJoinTournametQuery);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("get-all-users-ordered-by-score")]
        public async Task<ActionResult<List<GetAllUsersOrderedByScoreVm>>> GetAllUsersOrderedByScore()
        {
            var response = await _mediator.Send(new GetAllUsersOrderedByScoreQuery());

            return Ok(response);
        }
        [HttpGet("get-users-search-ordered-by-score")]
        public async Task<ActionResult<List<GetUsersWithKeywordOrderedByScoreVm>>> GetUsersWithKeywordOrderedByScore([FromQuery] GetUsersWithKeywordOrderedByScoreQuery getUsersWithKeywordOrderedByScoreQuery)
        {
            var response = await _mediator.Send(getUsersWithKeywordOrderedByScoreQuery);

            return Ok(response);
        }
    }
}

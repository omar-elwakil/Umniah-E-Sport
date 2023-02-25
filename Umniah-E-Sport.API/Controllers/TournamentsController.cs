using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.TermsAndCondtions.Queries.GetTermsAndConditionsByTournament;
using Umniah_E_Sport.Application.Features.Tournaments.Commands.CreateTournament;
using Umniah_E_Sport.Application.Features.Tournaments.Commands.DeleteTournament;
using Umniah_E_Sport.Application.Features.Tournaments.Commands.UpdateTournament;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetAllTournamets;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFeaturedTournaments;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFinishedTournaments;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetFinishedTournamentsByArenaId;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetLiveTournaments;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetLiveTournamentsByArenaId;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournament;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentGameURL;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentLeaderboard;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentRegistrantsCount;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByGameId;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByUserId;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournaments;
using Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournamentsByArenaId;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TournamentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-tournaments")]
        public async Task<ActionResult<List<GetAllTournamentsVM>>> GetAllTournamentsAsync()
        {
            var model = await _mediator.Send(new GetAllTournamentsQuery());
            return Ok(model);
        }

        [HttpGet("get-feature-tournaments")]
        public async Task<ActionResult<List<GetFeaturedTournamentsVM>>> GetAllFeatureTournamentsAsync()
        {
            var model = await _mediator.Send(new GetFeaturedTournamentsQuery());
            return Ok(model);
        }

        [HttpGet("get-upcoming-tournaments")]
        public async Task<ActionResult<List<GetUpcomingTournamentsVM>>> GetAllUpcomingTournamentsAsync([FromQuery] GetUpcomingTournamentsQuery getUpcomingTournamentsQuery)
        {
            var model = await _mediator.Send(getUpcomingTournamentsQuery);
            return Ok(model);
        }

        [HttpGet("get-live-tournaments")]
        public async Task<ActionResult<List<GetLiveTournamentsVM>>> GetAllLiveTournamentsAsync([FromQuery] GetLiveTournamentsQuery getLiveTournamentsQuery)
        {
            var model = await _mediator.Send(getLiveTournamentsQuery);
            return Ok(model);
        }

        [HttpGet("get-finished-tournaments")]
        public async Task<ActionResult<List<GetFinishedTournamentsVM>>> GetAllfinishedTournamentsAsync([FromQuery] GetFinishedTournamentsQuery getFinishedTournamentsQuery)
        {
            var model = await _mediator.Send(getFinishedTournamentsQuery);
            return Ok(model);
        }

        [HttpGet("get-tournament")]
        public async Task<ActionResult<GetTournamentVM>> GetTournamentAsync([FromQuery] GetTournamentQuery getTournamentQuery)
        {
            var tournament = await _mediator.Send(getTournamentQuery);
            var registerCount = await _mediator.Send(new GetTournamentRegistrantsCountQuery { tournamentId = getTournamentQuery.tournamentId });
            var leaderBoard = await _mediator.Send(new GetTournamentLeaderboardQuery { tournamentId = getTournamentQuery.tournamentId });

            if (tournament != null)
            {
                tournament.NumberOfRegistredPlayers = registerCount;
                tournament.UserTournaments = leaderBoard;
                return Ok(tournament);
            }
            return NotFound();
        }


        [HttpGet("get-terms-and-conditions")]
        public async Task<ActionResult<GetTermsAndConditionsByTournamentVM>> GetTermsAndConditionsTournamentsAsync([FromQuery] GetTermsAndConditionsByTournamentQuery getTermsAndConditionsByTournamentQuery)
        {
            var model = await _mediator.Send(getTermsAndConditionsByTournamentQuery);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }


        [HttpGet("get-game-link")]
        public async Task<ActionResult<GetTournamentGameURLVM>> GetTournamentGamLink([FromQuery] GetTournamentGameURLQuery getTournamentGameURLQuery)
        {
            var response = await _mediator.Send(getTournamentGameURLQuery);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("get-tournaments-by-user-id")]
        public async Task<ActionResult<List<GetTournamentsByUserIdVm>>> GetTournamentsByUserId([FromQuery] GetTournamentsByUserIdQuery getTournamentsByUserIdQuery)
        {
            var response = await _mediator.Send(getTournamentsByUserIdQuery);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("create-tournament")]
        public async Task<ActionResult<CreateTournamentCommandResponse>> CreateTournament(CreateTournamentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("update-tournament")]
        public async Task<ActionResult<UpdateTournamentCommandResponse>> UpdateTournament(UpdateTournamentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("delete-tournament")]
        public async Task<ActionResult<DeleteTournamentCommandResponse>> DeleteTournament(DeleteTournamentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("get-finished-tournaments-by-arenaId")]
        public async Task<ActionResult<List<GetFinishedTournamentsByArenaIdVM>>> GetFinishedTournamentsByArenaId([FromQuery] GetFinishedTournamentsByArenaIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("get-live-tournaments-by-arenaId")]
        public async Task<ActionResult<List<GetLiveTournamentsByArenaIdVM>>> GetLiveTournamentsByArenaId([FromQuery] GetLiveTournamentsByArenaIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("get-upcoming-tournaments-by-arenaId")]
        public async Task<ActionResult<List<GetUpcomingTournamentsByArenaIdVM>>> GetUpcomingTournamentsByArenaId([FromQuery] GetUpcomingTournamentsByArenaIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("get-tournaments-by-gameId")]
        public async Task<ActionResult<List<GetTournamentsByGameIdVM>>> GetTournamentsByGameId([FromQuery] GetTournamentsByGameIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}

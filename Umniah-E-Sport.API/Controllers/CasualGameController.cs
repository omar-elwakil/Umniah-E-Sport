using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.CasualGames.Commands.CreateCasualGame;
using Umniah_E_Sport.Application.Features.CasualGames.Commands.DeleteCasualGame;
using Umniah_E_Sport.Application.Features.CasualGames.Commands.UpdateCasualGame;
using Umniah_E_Sport.Application.Features.CasualGames.Queries.GetAllCasualGames;
using Umniah_E_Sport.Application.Features.CasualGames.Queries.GetCasualGameById;
using Umniah_E_Sport.Application.Features.CasualGames.Queries.GetCasualGamesByCategoryId;
using Umniah_E_Sport.Application.Features.CasualGames.Queries.GetFeaturedCasualGames;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasualGameController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CasualGameController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Get-All-Casual-Games")]
        public async Task<List<GetAllCasualGamesVm>> Get()
        {
            return await _mediator.Send(new GetAllCasualGamesQuery());
        }

        [HttpGet("Get-Casual-Game-By-Id")]
        public async Task<GetCasualGameByIdVm> GetCasualGameById([FromQuery]GetCasualGameByIdQuery getCasualGameByIdQuery)
        {
            return await _mediator.Send(getCasualGameByIdQuery);
        }
        [HttpGet("Get-All-Casual-Games-By-Category")]
        public async Task<List<GetCasualGamesByCategoryIdVm>> GetCasualGamesByCategory([FromQuery] GetCasualGamesByCategoryIdQuery getCasualGamesByCategoryIdQuery)
        {
            return await _mediator.Send(getCasualGamesByCategoryIdQuery);
        }
        [HttpGet("Get-Featured-Casual-Games")]
        public async Task<List<GetFeaturedCasualGamesVm>> GetFeaturedCasualGames([FromQuery] GetFeaturedCasualGamesQuery getFeaturedCasualGamesQuery)
        {
            return await _mediator.Send(getFeaturedCasualGamesQuery);
        }
        [HttpPost("Create-Casual-Game")]
        public async Task<CreateCasualGameResponse> Post([FromBody] CreateCasualGameCommand createCasualGameCommand)
        {
            return await _mediator.Send(createCasualGameCommand);
        }

        // PUT api/<CasualCategoryController>/5
        [HttpPut("Update-Casaul-Game")]
        public async Task<UpdateCasualGameResponse> Put([FromBody] UpdateCasualGameCommand updateCasualGameCommand)
        {
            return await _mediator.Send(updateCasualGameCommand);
        }

        // DELETE api/<CasualCategoryController>/5
        [HttpDelete("Delete-Casual-Game")]
        public async Task<DeleteCasualGameResponse> Delete([FromQuery] DeleteCasualGameCommand deleteCasualGameCommand)
        {
            return await _mediator.Send(deleteCasualGameCommand);
        }
    }
}

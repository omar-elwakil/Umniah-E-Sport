using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Badges.Queries.GetAllBadges;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BadgeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllBadgesVm>>> GetAllBadges()
        {
            var badges = await _mediator.Send(new GetAllBadgesQuery());
            return Ok(badges);
        }
    }
}

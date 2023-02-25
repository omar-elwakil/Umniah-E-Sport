using MediatR;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using Umniah_E_Sport.Application.Features.CasualGameImages.Commands.CreateCasualGameImage;
using Umniah_E_Sport.Application.Features.CasualGameImages.Commands.DeleteCasualGameImage;
using Umniah_E_Sport.Application.Features.CasualGameImages.Commands.UpdateCasualGameImage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasualGameImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CasualGameImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create-Casual-Game-Image")]
        public async Task<CreateCasualGameImageResponse> Post([FromBody] CreateCasualGameImageCommand createCasualGameImageCommand)
        {
            return await _mediator.Send(createCasualGameImageCommand);
        }

        // PUT api/<CasualCategoryController>/5
        [HttpPut("Update-Casaul-Game-Image")]
        public async Task<UpdateCasualGameImageResponse> Put([FromBody] UpdateCasualGameImageCommand updateCasualGameImageCommand)
        {
            return await _mediator.Send(updateCasualGameImageCommand);
        }

        // DELETE api/<CasualCategoryController>/5
        [HttpDelete("Delete-Casual-Game-Image")]
        public async Task<DeleteCasualGameImageResponse> Delete([FromQuery] DeleteCasualGameImageCommand deleteCasualGameImageCommand)
        {
            return await _mediator.Send(deleteCasualGameImageCommand);
        }
    }
}

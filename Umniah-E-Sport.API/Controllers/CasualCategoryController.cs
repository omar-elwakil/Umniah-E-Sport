using MediatR;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.CasualCategories.Commands.CreateCasualCategory;
using Umniah_E_Sport.Application.Features.CasualCategories.Commands.DeleteCasualCategory;
using Umniah_E_Sport.Application.Features.CasualCategories.Commands.UpdateCasualCategory;
using Umniah_E_Sport.Application.Features.CasualCategories.Queries.GetAllCasualCategories;
using Umniah_E_Sport.Application.Features.CasualCategories.Queries.GetCasualCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasualCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CasualCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Get-All-Casual-Categories")]
        public async Task<List<GetAllCasualCategoriesVm>> Get()
        {
            return await _mediator.Send(new GetAllCasualCategoriesQuery());
        }
        [HttpGet("Get-Casual-Category")]
        public async Task<GetCasualCategoryVm> GetCategory([FromQuery] GetCasualCategoryQuery getCasualCategoryQuery)
        {
            return await _mediator.Send(getCasualCategoryQuery);
        }

        [HttpPost("Create-Casual-Category")]
        public async Task<CreateCasualCategoryResponse> Post([FromBody] CreateCasualCategoryCommand createCasualCategoryCommand)
        {
            return await _mediator.Send(createCasualCategoryCommand);
        }

        // PUT api/<CasualCategoryController>/5
        [HttpPut("Update-Casaul-Category")]
        public async Task<UpdateCasualCategoryResponse> Put([FromBody] UpdateCasualCategoryCommand updateCasualCategoryCommand)
        {
            return await _mediator.Send(updateCasualCategoryCommand);
        }

        // DELETE api/<CasualCategoryController>/5
        [HttpDelete("Delete-Casual-Category")]
        public async Task<DeleteCasualCategoryResponse> Delete([FromQuery] DeleteCasualCategoryCommand deleteCasualCategoryCommand)
        {
            return await _mediator.Send(deleteCasualCategoryCommand);
        }
    }
}

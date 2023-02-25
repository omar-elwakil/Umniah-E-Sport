using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umniah_E_Sport.Application.Features.Locations.Commands.CreateLocation;
using Umniah_E_Sport.Application.Features.Locations.Commands.DeleteLocation;
using Umniah_E_Sport.Application.Features.Locations.Commands.UpdateLocation;
using Umniah_E_Sport.Application.Features.Locations.Queries.GetAllLocations;
using Umniah_E_Sport.Application.Features.Locations.Queries.GetLocationById;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Umniah_E_Sport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-locations")]
        public async Task<ActionResult<List<GetAllLocationsVM>>> GetAllLocationsAsync()
        {
            return await _mediator.Send(new GetAllLocationsQuery());
        }

        [HttpGet("get-location-by-id")]
        public async Task<ActionResult<GetLocationByIdVm>> GetLocationsByIdAsync([FromQuery]GetLocationByIdQuery getLocationByIdQuery)
        {
            return await _mediator.Send(getLocationByIdQuery);
        }

        [HttpPost("create-location")]
        public async Task<ActionResult<CreateLocationCommandResponse>> CreateLocationAsync([FromBody] CreateLocationCommand createLocationCommand)
        {
            return await _mediator.Send(createLocationCommand);
        }

        [HttpPut("update-location")]
        public async Task<ActionResult<UpdateLocationCommandResponse>> UpdateLocationAsync(UpdateLocationCommand updateLocationCommand)
        {
            return await _mediator.Send(updateLocationCommand);
        }

        [HttpDelete("delete-location")]
        public async Task<ActionResult<DeleteLocationCommandResponse>> DeleteLocation(DeleteLocationCommand deleteLocationCommand)
        {
            return await _mediator.Send(deleteLocationCommand);
        }


    }
}

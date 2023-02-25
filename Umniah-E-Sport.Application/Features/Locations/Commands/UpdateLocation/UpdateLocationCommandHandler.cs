using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationCommandResponse>
    {
        private readonly ILocationManager _locationManager;
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(ILocationManager locationManager, IMapper mapper)
        {
            _locationManager = locationManager;
            _mapper = mapper;
        }

        public async Task<UpdateLocationCommandResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            UpdateLocationCommandResponse response = new UpdateLocationCommandResponse();
            var location = await _locationManager.GetAsync(request.Id);
            if (location != null)
            {
                _mapper.Map<UpdateLocationCommand, Location>(request, location);
                await _locationManager.UpdateAsync(location);
                response.Success = true;
                return response;
            }
            else
            {
                response.Success = false;
                return response;
            }
        }
    }
}

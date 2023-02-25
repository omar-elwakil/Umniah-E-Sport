using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationCommandResponse>
    {
        private readonly ILocationManager _locationManager;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(ILocationManager locationManager, IMapper mapper)
        {
            _locationManager = locationManager;
            _mapper = mapper;
        }

        public async Task<CreateLocationCommandResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            CreateLocationCommandResponse response = new CreateLocationCommandResponse();
            var location = _mapper.Map<Location>(request);
            if (location != null)
            {
                await _locationManager.AddAsync(location);
                return response;
            }
            response.Success = false;
            response.Message = "Couldn't Create";
            return response;
        }
    }
}

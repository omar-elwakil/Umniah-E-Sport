using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Locations.Queries.GetLocationById
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdVm>
    {
        private readonly ILocationManager _locationManager;
        private readonly IMapper _mapper;

        public GetLocationByIdQueryHandler(ILocationManager locationManager, IMapper mapper)
        {
            _locationManager = locationManager;
            _mapper = mapper;
        }

        public async Task<GetLocationByIdVm> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationManager.GetAsync(request.Id);
            if (location == null)
            {
                return new GetLocationByIdVm { Success = false, Message = "Location not found" };
            }
            var getLocationByIdVm = _mapper.Map<GetLocationByIdVm>(location);
            getLocationByIdVm.Success = true;
            return getLocationByIdVm;
        }
    }
}

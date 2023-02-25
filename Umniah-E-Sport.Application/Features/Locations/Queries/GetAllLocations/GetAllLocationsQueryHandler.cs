using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Locations.Queries.GetAllLocations
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, List<GetAllLocationsVM>>
    {
        private readonly ILocationManager _locationManager;
        private readonly IMapper _mapper;

        public GetAllLocationsQueryHandler(ILocationManager locationManager, IMapper mapper)
        {
            _locationManager = locationManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllLocationsVM>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _locationManager.GetAllAsync();
            return _mapper.Map<List<GetAllLocationsVM>>(locations);
        }
    }
}

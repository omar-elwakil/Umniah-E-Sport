using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Locations.Queries.GetAllLocations
{
    public class GetAllLocationsQuery : IRequest<List<GetAllLocationsVM>>
    {
    }
}

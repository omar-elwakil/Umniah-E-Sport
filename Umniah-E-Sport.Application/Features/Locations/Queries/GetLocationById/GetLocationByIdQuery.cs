using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Locations.Queries.GetLocationById
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdVm>
    {
        public int Id { get; set; }
    }
}

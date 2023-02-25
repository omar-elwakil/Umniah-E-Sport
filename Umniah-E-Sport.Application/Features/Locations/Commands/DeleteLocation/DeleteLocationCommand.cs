using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommand : IRequest<DeleteLocationCommandResponse>
    {
        public int Id { get; set; }
    }
}

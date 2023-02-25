using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Locations.Commands.CreateLocation
{
    public class CreateLocationCommand : IRequest<CreateLocationCommandResponse>
    {
        public string Text_EN { get; set; }
        public string Text_AR { get; set; }
    }
}

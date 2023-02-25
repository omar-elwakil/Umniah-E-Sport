using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGameImages.Commands.CreateCasualGameImage
{
    public class CreateCasualGameImageCommand : IRequest<CreateCasualGameImageResponse>
    {
        public string ImageName { get; set; }
        public int CasualGameId { get; set; }
    }
}

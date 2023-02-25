using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGameImages.Commands.UpdateCasualGameImage
{
    public class UpdateCasualGameImageCommand : IRequest<UpdateCasualGameImageResponse>
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int CasualGameId { get; set; }

    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGameImages.Commands.DeleteCasualGameImage
{
    public class DeleteCasualGameImageCommand : IRequest<DeleteCasualGameImageResponse>
    {
        public int Id { get; set; }
    }
}

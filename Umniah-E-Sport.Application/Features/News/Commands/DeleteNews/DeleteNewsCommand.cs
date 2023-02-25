using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest<DeleteNewsCommandResponse>
    {
        public int Id { get; set; }
    }
}

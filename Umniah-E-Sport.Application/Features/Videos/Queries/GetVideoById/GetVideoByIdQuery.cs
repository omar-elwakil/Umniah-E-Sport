using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetVideoById
{
    public class GetVideoByIdQuery : IRequest<GetVideoByIdVm>
    {
        public int VideoId { get; set; }
    }
}

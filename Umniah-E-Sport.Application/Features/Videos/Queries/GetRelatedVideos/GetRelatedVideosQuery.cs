using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetRelatedVideos
{
    public class GetRelatedVideosQuery : IRequest<IEnumerable<GetRelatedVideosVm>>
    {
        public int VideoId { get; set; }
    }
}

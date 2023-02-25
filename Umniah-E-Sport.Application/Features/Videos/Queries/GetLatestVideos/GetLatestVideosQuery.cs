using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetLatestVideos
{
    public class GetLatestVideosQuery : IRequest<IEnumerable<GetLatestVideosVm>>
    {
        public int VideosCount { get; set; }
    }
}

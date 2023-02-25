using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetLatestVideos
{
    public class GetLatestVideosQueryHandler : IRequestHandler<GetLatestVideosQuery, IEnumerable<GetLatestVideosVm>>
    {
        private readonly IVideoManager _videoRepo;
        private readonly IMapper _mapper;

        public GetLatestVideosQueryHandler(IVideoManager videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetLatestVideosVm>> Handle(GetLatestVideosQuery request, CancellationToken cancellationToken)
        {
            var videos = _videoRepo.GetLatestVideos(request.VideosCount);
            var videosVm = _mapper.Map<IEnumerable<GetLatestVideosVm>>(videos);
            return Task.FromResult(videosVm);
        }
    }
}

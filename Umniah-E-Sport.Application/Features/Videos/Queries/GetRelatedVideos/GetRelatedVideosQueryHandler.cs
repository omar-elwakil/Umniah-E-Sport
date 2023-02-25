using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetRelatedVideos
{
    public class GetRelatedVideosQueryHandler : IRequestHandler<GetRelatedVideosQuery, IEnumerable<GetRelatedVideosVm>>
    {
        private readonly IVideoManager _videoRepo;
        private readonly IMapper _mapper;

        public GetRelatedVideosQueryHandler(IVideoManager videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetRelatedVideosVm>> Handle(GetRelatedVideosQuery request, CancellationToken cancellationToken)
        {
            var videos = _videoRepo.GetRelatedVideos(request.VideoId);
            var videosVm = _mapper.Map<IEnumerable<GetRelatedVideosVm>>(videos);
            return Task.FromResult(videosVm);
        }
    }
}

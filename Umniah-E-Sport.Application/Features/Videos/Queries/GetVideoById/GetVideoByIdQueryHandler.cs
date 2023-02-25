using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Application.Features.Videos.Queries.GetRelatedVideos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetVideoById
{
    public class GetVideoByIdQueryHandler : IRequestHandler<GetVideoByIdQuery, GetVideoByIdVm>
    {
        private readonly IVideoManager _videoRepo;
        private readonly IMapper _mapper;

        public GetVideoByIdQueryHandler(IVideoManager videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public async Task<GetVideoByIdVm> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
        {
            var video = await _videoRepo.GetAsync(request.VideoId);
            if (video != null)
            {
                var relatedVideos = _videoRepo.GetRelatedVideos(request.VideoId);
                var videoVm = _mapper.Map<GetVideoByIdVm>(video);
                videoVm.RelatedVideosVms = _mapper.Map<IEnumerable<GetRelatedVideosVm>>(relatedVideos);
                return videoVm;
            }
            return null;
        }
    }
}

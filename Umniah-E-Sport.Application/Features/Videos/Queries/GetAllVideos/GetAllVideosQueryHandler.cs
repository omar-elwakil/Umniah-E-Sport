using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetAllVideos
{
    public class GetAllVideosQueryHandler : IRequestHandler<GetAllVideosQuery, IEnumerable<GetAllVideosVm>>
    {
        private readonly IVideoManager _videoRepo;
        private readonly IMapper _mapper;

        public GetAllVideosQueryHandler(IVideoManager videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllVideosVm>> Handle(GetAllVideosQuery request, CancellationToken cancellationToken)
        {
            var videos = await _videoRepo.GetAllAsync();
            var videosVm = _mapper.Map<IEnumerable<GetAllVideosVm>>(videos);
            return videosVm;
        }
    }
}

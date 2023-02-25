using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetVideosByGame
{
    public class GetVideosByGameQueryHandler : IRequestHandler<GetVideosByGameQuery, IEnumerable<GetVideosByGameVm>>
    {
        private readonly IVideoManager _videoRepo;
        private readonly IMapper _mapper;

        public GetVideosByGameQueryHandler(IVideoManager videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetVideosByGameVm>> Handle(GetVideosByGameQuery request, CancellationToken cancellationToken)
        {
            var videos = _videoRepo.GetVideosByGame(request.GamedId);
            var videosVm = _mapper.Map<IEnumerable<GetVideosByGameVm>>(videos);
            return Task.FromResult(videosVm);
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Commands.UpdateVideoById
{
    public class UpdateVideoByIdCommandHandler : IRequestHandler<UpdateVideoByIdCommand, UpdateVideoByIdVm>
    {
        private readonly IVideoManager _videoRepo;
        private readonly IMapper _mapper;

        public UpdateVideoByIdCommandHandler(IVideoManager videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public async Task<UpdateVideoByIdVm> Handle(UpdateVideoByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var video = await _videoRepo.GetAsync(request.Id);
                if(video == null)
                {
                    return new UpdateVideoByIdVm { Success = false,Message = "Video not found" };
                }
                _mapper.Map(request, video);
                await _videoRepo.UpdateAsync(video);
                return new UpdateVideoByIdVm { Success = true };
            }
            catch (Exception ex)
            {
                return new UpdateVideoByIdVm { Success = false, Message = ex.InnerException.Message };
            }
        }
    }
}

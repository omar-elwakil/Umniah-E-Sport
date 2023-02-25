using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Commands.DeleteVideoById
{
    public class DeleteVideoByIdCommandHandler : IRequestHandler<DeleteVideoByIdCommand, DeleteVideoByIdVm>
    {
        private readonly IVideoManager _videoRepo;

        public DeleteVideoByIdCommandHandler(IVideoManager videoRepo)
        {
            _videoRepo = videoRepo;
        }

        public async Task<DeleteVideoByIdVm> Handle(DeleteVideoByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var video = await _videoRepo.GetAsync(request.Id);
                if (video == null)
                {
                    return new DeleteVideoByIdVm { Success = false, Message = "Video not found" };
                }
                video.IsDeleted = true;
                await _videoRepo.UpdateAsync(video);
                return new DeleteVideoByIdVm { Success = true };
            }
            catch (Exception ex)
            {
                return new DeleteVideoByIdVm { Success = false, Message = ex.InnerException.Message };
            }
        }
    }
}

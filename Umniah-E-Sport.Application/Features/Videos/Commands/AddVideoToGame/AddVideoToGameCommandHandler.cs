using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Commands.AddVideoToGame
{
    public class AddVideoToGameCommandHandler : IRequestHandler<AddVideoToGameCommand, AddVideoToGameVm>
    {
        private readonly IVideoManager _videoRepo;
        private readonly IMapper _mapper;

        public AddVideoToGameCommandHandler(IVideoManager videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public async Task<AddVideoToGameVm> Handle(AddVideoToGameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var video = _mapper.Map<Video>(request);
                await _videoRepo.AddAsync(video);
                return new AddVideoToGameVm { Success = true };
            }
            catch (Exception ex)
            {
                return new AddVideoToGameVm { Success = false, Message = ex.InnerException.Message };
            }
        }
    }
}

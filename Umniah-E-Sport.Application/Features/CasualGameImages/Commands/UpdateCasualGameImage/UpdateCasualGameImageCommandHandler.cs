using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGameImages.Commands.UpdateCasualGameImage
{
    public class UpdateCasualGameImageCommandHandler : IRequestHandler<UpdateCasualGameImageCommand, UpdateCasualGameImageResponse>
    {

        private readonly ICasualGameImagesManager _casualGameImageManager;
        private readonly IMapper _mapper;

        public UpdateCasualGameImageCommandHandler(ICasualGameImagesManager casualGameImageManager, IMapper mapper)
        {
            _casualGameImageManager = casualGameImageManager;
            _mapper = mapper;
        }

        public async Task<UpdateCasualGameImageResponse> Handle(UpdateCasualGameImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _casualGameImageManager.GetAsync(request.Id);
            if (image == null)
                return new UpdateCasualGameImageResponse { Success = false, Message = "Not found" };
            _mapper.Map(request, image);
            await _casualGameImageManager.UpdateAsync(image);
            return new UpdateCasualGameImageResponse { Success = true };
        }
    }
}

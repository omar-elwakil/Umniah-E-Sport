using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGameImages.Commands.DeleteCasualGameImage
{
    public class DeleteCasualGameImageCommandHandler : IRequestHandler<DeleteCasualGameImageCommand, DeleteCasualGameImageResponse>
    {

        private readonly ICasualGameImagesManager _casualGameImageManager;

        public DeleteCasualGameImageCommandHandler(ICasualGameImagesManager casualGameImageManager)
        {
            _casualGameImageManager = casualGameImageManager;
        }

        public async Task<DeleteCasualGameImageResponse> Handle(DeleteCasualGameImageCommand request, CancellationToken cancellationToken)
        {

            var image = await _casualGameImageManager.GetAsync(request.Id);
            if (image == null)
            {
                return new DeleteCasualGameImageResponse { Success = false, Message = "Not found" };
            }

            image.IsDeleted = true;
            await _casualGameImageManager.UpdateAsync(image);
            return new DeleteCasualGameImageResponse { Success = true };
        }
    }
}

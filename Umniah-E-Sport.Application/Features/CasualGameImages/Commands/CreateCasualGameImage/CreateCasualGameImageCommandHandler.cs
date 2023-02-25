using AutoMapper;
using Umniah_E_Sport.Domain.Entities;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.CasualGameImages.Commands.CreateCasualGameImage
{
    public class CreateCasualGameImageCommandHandler : IRequestHandler<CreateCasualGameImageCommand, CreateCasualGameImageResponse>
    {
        private readonly ICasualGameImagesManager _casualGameImageManager;
        private readonly IMapper _mapper;

        public CreateCasualGameImageCommandHandler(ICasualGameImagesManager casualGameImageManager, IMapper mapper)
        {
            _casualGameImageManager = casualGameImageManager;
            _mapper = mapper;
        }

        public async Task<CreateCasualGameImageResponse> Handle(CreateCasualGameImageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var image = _mapper.Map<CasualGameImage>(request);
                if (image == null)
                    return new CreateCasualGameImageResponse { Success = false, Message = "Value can't be null" };
                await _casualGameImageManager.AddAsync(image);
                return new CreateCasualGameImageResponse { Success = true };
            }
            catch (Exception ex)
            {
                return new CreateCasualGameImageResponse { Success = false, Message = ex.Message };
            }
        }
    }
}

using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.CheckIfVideoExist
{
    public class CheckIfVideoExistQueryHandler : IRequestHandler<CheckIfVideoExistQuery, CheckIfVideoExistVm>
    {
        private readonly IVideoManager _videoRepo;

        public CheckIfVideoExistQueryHandler(IVideoManager videoRepo)
        {
            _videoRepo = videoRepo;
        }

        public async Task<CheckIfVideoExistVm> Handle(CheckIfVideoExistQuery request, CancellationToken cancellationToken)
        {
            var video = await _videoRepo.GetAsync(request.Id);
            if (video == null)
            {
                return new CheckIfVideoExistVm { Success = true, IsExist = false };
            }
            return new CheckIfVideoExistVm { Success = true, IsExist = true };
        }
    }
}

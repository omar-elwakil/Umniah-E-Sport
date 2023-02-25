using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.News.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, UpdateNewsCommandResponse>
    {
        private readonly INewsManager _newsRepo;
        private readonly IMapper _mapper;

        public UpdateNewsCommandHandler(INewsManager newsRepo, IMapper mapper)
        {
            _newsRepo = newsRepo;
            _mapper = mapper;
        }

        public async Task<UpdateNewsCommandResponse> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            UpdateNewsCommandResponse response = new UpdateNewsCommandResponse();
            var news = await _newsRepo.GetAsync(request.Id);
            if (news != null)
            {
                _mapper.Map<UpdateNewsCommand, NewsEntity>(request, news);
                await _newsRepo.UpdateAsync(news);
                return response;
            }
            response.Success = false;
            response.Message = "Not Found";
            return response;
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
namespace Umniah_E_Sport.Application.Features.News.Commands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, CreateNewsCommandResponse>
    {
        private readonly INewsManager _newsManager;
        private readonly IMapper _mapper;

        public CreateNewsCommandHandler(INewsManager newsManager, IMapper mapper)
        {
            _newsManager = newsManager;
            _mapper = mapper;
        }

        public async Task<CreateNewsCommandResponse> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            CreateNewsCommandResponse response = new CreateNewsCommandResponse();
            var news = _mapper.Map<NewsEntity>(request);
            if (news != null)
            {
                await _newsManager.AddAsync(news);
                response.Success = true;
                return response;
            }
            response.Success = false;
            response.Message = "Failed";
            return response;

        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.News.Quereis.GetLatestNews
{
    public class GetLatestNewsQueryHandler : IRequestHandler<GetLatestNewsQuery, List<LatestNewsCardVM>>
    {
        private readonly INewsManager _newsRepo;
        private readonly IMapper _mapper;

        public GetLatestNewsQueryHandler(INewsManager newsRepo, IMapper mapper)
        {
            _newsRepo = newsRepo;
            _mapper = mapper;
        }

        public async Task<List<LatestNewsCardVM>> Handle(GetLatestNewsQuery request, CancellationToken cancellationToken)
        {
            var latestNews = await _newsRepo.GetLatesdNews(request.NewsCount);
            return _mapper.Map<List<LatestNewsCardVM>>(latestNews);
        }
    }
}

using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.News.Quereis.GetNews
{
    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, NewsCardDetailVM>
    {
        private readonly INewsManager _newsRepo;
        private readonly IMapper _mapper;

        public GetNewsQueryHandler(INewsManager newsRepo, IMapper mapper)
        {
            _newsRepo = newsRepo;
            _mapper = mapper;
        }

        public async Task<NewsCardDetailVM> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var newsDetail = await _newsRepo.GetAsync(request.NewsId);

            if(newsDetail != null)
            {
                var videoDetail = _mapper.Map<NewsCardDetailVM>(newsDetail);
                var relatedNews = await _newsRepo.GetRelatedNews(newsDetail.Id);
                videoDetail.RelatedNews = _mapper.Map<List<RelatedNewsCardVM>>(relatedNews);

                return videoDetail;
            }

            return null;
        }
    }
}

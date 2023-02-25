using AutoMapper;
using MediatR;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Application.Features.News.Quereis.GetAllNews
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, List<NewsCardVM>>
    {
        private readonly INewsManager _newsRepo;
        private readonly IMapper _mapper;

        public GetAllNewsQueryHandler(INewsManager newsRepo, IMapper mapper)
        {
            _newsRepo = newsRepo;
            _mapper = mapper;
        }

        public async Task<List<NewsCardVM>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsRepo.GetAllAsync();
            return _mapper.Map<List<NewsCardVM>>(news);
        }
    }
}

using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.News.Quereis.GetLatestNews
{
    public class GetLatestNewsQuery : IRequest<List<LatestNewsCardVM>>
    {
        public int NewsCount { get; set; }
    }
}

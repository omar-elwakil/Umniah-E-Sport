using MediatR;

namespace Umniah_E_Sport.Application.Features.News.Quereis.GetNews
{
    public class GetNewsQuery : IRequest<NewsCardDetailVM>
    {
        public int NewsId { get; set; }
    }
}

using MediatR;
using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.News.Quereis.GetAllNews
{
    public class GetAllNewsQuery : IRequest<List<NewsCardVM>>
    {
    }
}

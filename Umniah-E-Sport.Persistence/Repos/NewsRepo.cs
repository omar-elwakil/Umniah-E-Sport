using Microsoft.EntityFrameworkCore;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class NewsRepo : BaseManager<NewsEntity>, INewsManager
    {
        public NewsRepo(UmniahContext context) : base(context)
        {
        }

        public async Task<IEnumerable<NewsEntity>> GetLatesdNews(int newsCount)
        {
            return await _context.News.AsQueryable().OrderByDescending(e => e.TimeStamp).Take(newsCount).ToListAsync();
        }

        public async Task<IEnumerable<NewsEntity>> GetRelatedNews(int newsId)
        {
            var news = _context.News.AsQueryable().FirstOrDefault(e => e.Id == newsId);
            if (news == null)
            {
                return new List<NewsEntity>();
            }
            return await _context.News
                .AsQueryable()
                .Where(e => e.GameId == news.GameId && e.Id != newsId)
                .Take(4).ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface INewsManager : IAsyncManager<NewsEntity>
    {
        public Task<IEnumerable<NewsEntity>> GetRelatedNews(int newsId);
        public Task<IEnumerable<NewsEntity>> GetLatesdNews(int newsCount);
    }
}

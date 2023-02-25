using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface ICasualGameManager : IAsyncManager<CasualGame>
    {
        public Task<List<CasualGame>> GetFeaturedCasualGame(int count);
        public Task<List<CasualGame>> GetCasualGameByCategoryId(int categoryId);
       
    }
}

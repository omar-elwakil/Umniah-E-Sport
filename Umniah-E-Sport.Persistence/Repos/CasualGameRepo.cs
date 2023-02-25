using Umniah_E_Sport.Domain.Entities;
using Umniah_E_Sport.Persistence;
using Umniah_E_Sport.Persistence.Repos;
using Microsoft.EntityFrameworkCore;
using Umniah_E_Sport.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class CasualGameRepo : BaseManager<CasualGame>,ICasualGameManager
    {
        public CasualGameRepo(UmniahContext context) : base(context)
        {
        }

        public async Task<List<CasualGame>> GetCasualGameByCategoryId(int categoryId)
        {
            return await _context.CasualGames
                .AsQueryable()
                .Where(cg => cg.CasualCategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<CasualGame>> GetFeaturedCasualGame(int count)
        {
            return await _context.CasualGames
                .AsQueryable()
                .Where(cg => cg.IsFreatured)
                .Take(count)
                .ToListAsync();
        }
    }
}

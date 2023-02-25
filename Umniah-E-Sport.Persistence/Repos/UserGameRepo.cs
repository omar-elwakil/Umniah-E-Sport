using Microsoft.EntityFrameworkCore;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class UserGameRepo : BaseManager<UserGames>, IUserGameManager
    {
        public UserGameRepo(UmniahContext context) : base(context)
        {
        }

        public async Task<UserGames> GetUsersGames(int gameId, int userId)
        {
            return await _context.UserGames
                            .AsQueryable()
                            .FirstOrDefaultAsync(u => u.GameId == gameId && u.UserId == userId);
        }

        public async Task<IEnumerable<UserGames>> GetUsersByGame(int gameId)
        {
            return await _context.UserGames
                            .AsQueryable()
                            .Where(U => U.GameId == gameId).ToListAsync();
        }
    }
}

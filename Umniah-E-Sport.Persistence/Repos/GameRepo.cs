using Microsoft.EntityFrameworkCore;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Application.Features.Games.Commands.AddGame;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class GameRepo : BaseManager<Game>, IGameManager
    {
        public GameRepo(UmniahContext context) : base(context)
        {
        }

        public async Task<bool> DeleteGameAsync(int gameId)
        {
            try
            {
                var game = await _context.Games.AsQueryable().FirstOrDefaultAsync(g => g.Id == gameId);
                if (game == null)
                {
                    return false;
                }

                game.IsDeleted = true;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Task<bool> EditGame(Game game)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UserGames>> GetUserGamesByUserIdAsync(int userId)
        {
            return await _context.UserGames.AsQueryable().Where(ug=>ug.UserId==userId).ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetTrendingGames(int Count)
        {
            List<Game> games = await _context.Games.Take(Count).ToListAsync();
            return games;
        }

        public async Task<bool> PostGameAsync(Game game)
        {
            try
            {
                await _context.AddAsync(game);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

    }
}

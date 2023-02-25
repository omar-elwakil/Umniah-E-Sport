using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface IGameManager : IAsyncManager<Game>
    {
        public Task<IEnumerable<Game>> GetTrendingGames(int count);
        public Task<bool> PostGameAsync(Game game);
        public Task<bool> EditGame(Game game);
        public Task<bool> DeleteGameAsync(int gameId);
        public Task<List<UserGames>> GetUserGamesByUserIdAsync(int userId);

    }
}

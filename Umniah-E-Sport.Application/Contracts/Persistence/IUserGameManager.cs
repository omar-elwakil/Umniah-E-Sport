using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface IUserGameManager : IAsyncManager<UserGames>
    {
        public Task<IEnumerable<UserGames>> GetUsersByGame(int gameId);
        public Task<UserGames> GetUsersGames(int gameId,int userId);
    }
}

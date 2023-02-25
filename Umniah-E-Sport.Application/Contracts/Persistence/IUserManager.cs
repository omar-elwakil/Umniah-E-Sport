using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.DTOs.LeaderBoard;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface IUserManager : IAsyncManager<User>
    {
        public User GetByEmail(string email);
        public User GetByMSISDN(string msisdn);
        public Task<IEnumerable<User>> GetLeaderBoard();
        public Task<IEnumerable<UserGames>> GetUserLeaderBoard(string MSISDN);
        public IEnumerable<LeaderBoardRankDTO> GetRankingUser(string msisdn, int gameId, int listLength);
        public bool WelcomeBadge(string msisdn);
        public bool EarlyBadge(string msisdn, int tournamentId);
        public bool ActiveBadge(string msisdn);
        public IEnumerable<User> GetUsersBySearchKeyword(string keyword);
    }
}

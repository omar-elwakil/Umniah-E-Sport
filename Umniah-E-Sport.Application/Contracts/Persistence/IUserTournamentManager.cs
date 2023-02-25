using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface IUserTournamentManager : IAsyncManager<UserTournaments>
    {
        public bool AddUserTournments(string userName, string ingameId, int userId, int tournamentId);
        public UserTournaments GetUserTournamentByUserIdAndTournamentId(int userId, int tournamentId);
    }
}

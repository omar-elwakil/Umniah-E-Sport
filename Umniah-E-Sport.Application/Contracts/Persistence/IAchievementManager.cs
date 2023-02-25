using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface IAchievementManager :IAsyncManager<Achievement>
    {
        public IEnumerable<Achievement> GetUserAchievementsByMsisdn(string Msisdn);
        public IEnumerable<Achievement> GetUserAchievementsByUserId(int UserId);
        //object GetUserAchievementsByUserId(int userId);
    }
}

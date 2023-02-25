using Microsoft.EntityFrameworkCore;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class AchievementRepo : BaseManager<Achievement>, IAchievementManager
    {
        public AchievementRepo(UmniahContext context) : base(context)
        {

        }
        public IEnumerable<Achievement> GetUserAchievementsByMsisdn(string Msisdn)
        {
            return _context.Achievements.AsQueryable().Include(a => a.User).Where(u => u.User.Msisdn == Msisdn);
        }

        public IEnumerable<Achievement> GetUserAchievementsByUserId(int UserId)
        {
            return _context.Achievements.AsQueryable().Include(a => a.User).Where(u => u.User.Id == UserId);
        }
    }

   
}

using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class UserTournamentRepo : BaseManager<UserTournaments>,IUserTournamentManager
    {
        private readonly IUserManager _userRepo;
        public UserTournamentRepo(UmniahContext context, IUserManager userRepo) : base(context)
        {
            _userRepo = userRepo;
        }

        public bool AddUserTournments(string userName, string ingameId, int userId, int tournamentId)
        {
            try
            {
                UserTournaments userTournament = new UserTournaments()
                {
                    TimeStamp = DateTime.Now,
                    UserId = userId,
                    TournamentId = tournamentId,
                    UserName = userName,
                    IngameId = ingameId,
                    IsTheFirst = false,
                    IsDailySmsSent = false,
                    IsHourlySmsSent = false,
                    IsJoinSmsSent = true
                };
                _context.UserTournaments.Add(userTournament);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserTournaments GetUserTournamentByUserIdAndTournamentId(int userId, int tournamentId)
        {
            return _context.UserTournaments.AsQueryable().FirstOrDefault(us => us.TournamentId == tournamentId && us.UserId == userId);
        }
    }
}

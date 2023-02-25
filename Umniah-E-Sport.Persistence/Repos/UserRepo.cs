using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.DTOs.LeaderBoard;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain;
using Microsoft.Extensions.Options;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class UserRepo : BaseManager<User>, IUserManager
    {
        public UserRepo(UmniahContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetLeaderBoard()
        {
            return await _context.Users
                            .AsQueryable()
                            .Include(u => u.Achievements)
                            .OrderByDescending(u => u.Score)
                            .ToListAsync();
        }


        public async Task<IEnumerable<UserGames>> GetUserLeaderBoard(string MSISDN)
        {
            var user = _context.Users
                            .AsQueryable()
                            .FirstOrDefault(u => u.Msisdn == MSISDN);
            if (user == null)
            {
                return null;
            }
            return await _context.UserGames
                            .AsQueryable()
                            .Include(ug => ug.Game)
                            .Where(ug => ug.UserId == user.Id)
                            .OrderByDescending(u => u.UserScore)
                            .ToListAsync();
        }

        public IEnumerable<LeaderBoardRankDTO> GetRankingUser(string msisdn, int gameId, int listLength)
        {

            var allRankings = GetUserGameLeaderboard(msisdn, gameId);

            int currentUserIndex = 0;
            foreach (var item in allRankings)
            {
                if (item.IsCurrentUser)
                {
                    currentUserIndex = item.Rank;
                    break;
                }
            }

            if (currentUserIndex >= listLength)
            {
                //GameLeaderboard.CurrentUserIndex = listLength / 2 + 1;
                allRankings = allRankings
                    .Skip(currentUserIndex - (listLength / 2 + 1))
                    .Take(listLength);
                // 10
                // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19
                // 13 - 5 => 8, 9, 10, 11, 12, 13, 
            }
            else
            {
                //GameLeaderboard.CurrentUserIndex = currentUserIndex;
                allRankings = allRankings.Take(listLength);
            }

            return allRankings;
        }

        private IEnumerable<LeaderBoardRankDTO> GetUserGameLeaderboard(string Msisdn, int gameId)
        {
            var allRankings = _context.UserGames
                            .AsQueryable()
                            .Include(ug => ug.User)
                            .Where(ug => ug.GameId == gameId)
                            .OrderByDescending(ug => ug.UserScore)
                            .Select((ug, index) => new LeaderBoardRankDTO()
                            {
                                Rank = index + 1,
                                Name = ug.User.Name,
                                Score = ug.UserScore,
                                IsCurrentUser = ug.User.Msisdn == Msisdn
                            });
            return allRankings;
        }

        public bool WelcomeBadge(string msisdn)
        {
            try
            {
                var badge = _context.Badges.AsQueryable().FirstOrDefault(b => b.Name_EN == "Welcome");
                if (badge == null)
                {
                    badge = new Badge
                    {
                        Name_AR = "أهلا",
                        Name_EN = "Welcome",
                        ImageName = "welcome.png"
                    };
                    _context.Badges.Add(badge);
                    _context.SaveChanges();
                }
                User user = _context.Users.AsQueryable().Include(u => u.Achievements).FirstOrDefault(u => u.Msisdn == msisdn);

                Achievement achievement = new Achievement()
                {
                    UserId = user.Id,
                    ImageName = badge.ImageName,
                    Name_EN = badge.Name_EN,
                    Name_AR = badge.Name_AR
                };
                _context.Achievements.Add(achievement);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EarlyBadge(string msisdn, int tournamentId)
        {
            try
            {
                var badge = _context.Badges.AsQueryable().FirstOrDefault(b => b.Name_EN == "Early bird");
                if (badge == null)
                {
                    badge = new Badge
                    {
                        Name_AR = "أهلا",
                        Name_EN = "Early bird",
                        ImageName = "Early.png"
                    };
                    _context.Badges.Add(badge);
                    _context.SaveChanges();
                }
                User user = _context.Users.AsQueryable().Include(u => u.Achievements).FirstOrDefault(u => u.Msisdn == msisdn);
                int count = _context.UserTournaments.AsQueryable().Where(t => t.TournamentId == tournamentId).Count();
                if (count == 1)
                {

                    Achievement achievement = new Achievement()
                    {
                        UserId = user.Id,
                        ImageName = badge.ImageName,
                        Name_EN = badge.Name_EN,
                        Name_AR = badge.Name_AR
                    };
                    _context.Achievements.Add(achievement);

                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool ActiveBadge(string msisdn)
        {
            try
            {
                var badge = _context.Badges.AsQueryable().FirstOrDefault(b => b.Name_EN == "Active");
                if (badge == null)
                {
                    badge = new Badge
                    {
                        Name_AR = "أهلا",
                        Name_EN = "Active",
                        ImageName = "Active.png"
                    };
                    _context.Badges.Add(badge);
                    _context.SaveChanges();
                }
                User user = _context.Users.AsQueryable().Include(u => u.Achievements).FirstOrDefault(u => u.Msisdn == msisdn);
                int count = _context.UserTournaments.AsQueryable().Where(u => u.UserId == user.Id).Count();
                if (count == 5)
                {
                    Achievement achievement = new Achievement()
                    {
                        UserId = user.Id,
                        ImageName = badge.ImageName,
                        Name_EN = badge.Name_EN,
                        Name_AR = badge.Name_AR
                    };
                    _context.Achievements.Add(achievement);

                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public IEnumerable<User> GetUsersBySearchKeyword(string keyword)
        {
            return _context.Users.AsQueryable().Where(u => u.Name.Contains(keyword)).ToList();
        }
        public User GetByMSISDN(string msisdn)
        {
            if (msisdn == null || msisdn == "")
                return null;

            return _context.Users.AsQueryable().Include(u => u.Achievements)
                .FirstOrDefault(u => u.Msisdn == msisdn);
        }

        public User GetByEmail(string email)
        {
            if (email == null || email == "")
                return null;

            return _context.Users
                .AsQueryable()
                .Include(u => u.Achievements)
                .FirstOrDefault(u => u.Email == email);
        }

    }
}

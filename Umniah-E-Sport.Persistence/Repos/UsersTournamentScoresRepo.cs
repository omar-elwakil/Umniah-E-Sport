using Microsoft.EntityFrameworkCore;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Application.Features.UserTournament.Commands.AddUsersScores;
using Umniah_E_Sport.Application.Responses;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class UsersTournamentScoresRepo : IUsersTournamentScoresManager
    {
        private readonly UmniahContext _context;
        
        public UsersTournamentScoresRepo(UmniahContext context)
        {
            _context = context;
        }

        public BaseResponse AddUsersTournamentScores(List<AddUsersScoresCommandItem> addUsersScoresCommandItems)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Logic of mainupilate data
                    List<UserTournaments> userTornaments = new List<UserTournaments>();
                    foreach (var item in addUsersScoresCommandItems)
                    {
                        var user = _context.Users.AsQueryable().FirstOrDefault(u => u.Msisdn == item.Msisdn);
                        var tournament = _context.Tournaments.AsQueryable()
                            .Include(t => t.Game)
                            .ThenInclude(g => g.UserGames)
                            .FirstOrDefault(u => u.DiscordLink == item.DiscordLink);


                        // update users' game score in usergame table
                        var game = tournament?.Game;
                        if (game != null)
                        {
                            var userGame = game.UserGames.FirstOrDefault(g => g.User == user);
                            if (userGame != null)
                            {
                                userGame.UserScore += item.UserScore;
                                _context.SaveChanges();
                            }
                        }

                        if (user != null && tournament != null)
                        {
                            try
                            {
                                var userTornament = _context.UserTournaments.AsQueryable()
                                    .FirstOrDefault(ut => ut.Tournament == tournament && ut.User == user);
                                if (userTornament != null)
                                {
                                    userTornament.Score = item.UserScore;
                                    _context.UserTournaments.Update(userTornament);
                                    userTornaments.Add(userTornament);
                                }

                            }
                            catch (Exception)
                            {
                                // do nothing
                            }

                        }
                    }
                    _context.SaveChanges();


                    if (userTornaments.Count > 0)
                    {
                        List<UserTournaments> firstThreeUsers = userTornaments.OrderByDescending(u => u.Score).Take(3).ToList();

                        firstThreeUsers.FirstOrDefault().IsTheFirst = true;

                        FirstThreeWinner(firstThreeUsers);


                        FirstBloodBadge(firstThreeUsers.FirstOrDefault());
                        WinningStreakBadge(firstThreeUsers.FirstOrDefault());

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new BaseResponse { Success = false, Message = ex.Message };
                }
            }
            return new BaseResponse { Success = true };
        }

        private void FirstThreeWinner(List<UserTournaments> firstThreeUsers)
        {

            int bigPrize = 600; // 600 for 1th , 400 for 2th , 200 for 3th
            foreach (var winner in firstThreeUsers)
            {
                var user = _context.Users.AsQueryable().FirstOrDefault(u => u == winner.User);
                user.Score += bigPrize;

                bigPrize = bigPrize - 200;

            }
            _context.SaveChanges();
        }

        //First win for first game after registration on Vodafone play.
        //Powered by (Amr Samy)
        private void FirstBloodBadge(UserTournaments firstWinner)
        {
            int count = _context.UserTournaments.AsQueryable()
                .Where(u => u.UserId == firstWinner.UserId).Count();

            if (count == 1)
            {
                // Logic start her Powered by (Amr Samy)
                var badge = _context.Badges.AsQueryable().FirstOrDefault(b => b.Name_EN == "First blood");
                if (badge != null)
                {
                    Achievement achievement = new Achievement()
                    {
                        UserId = firstWinner.UserId,
                        ImageName = badge.ImageName,
                        Name_EN = badge.Name_EN,
                        Name_AR = badge.Name_AR,
                    };
                    _context.Achievements.Add(achievement);

                    _context.SaveChanges();
                }
            }
        }

        //Win tournament in a row without any lose
        //Powered by (Amr Samy)
        private void WinningStreakBadge(UserTournaments firstWinner)
        {
            var userTournaments = _context.UserTournaments.AsQueryable()
                .Where(u => u.UserId == firstWinner.UserId)
                .OrderByDescending(u => u.TimeStamp).ToList();

            if (userTournaments.Count >= 2)
            {
                if (userTournaments[1].IsTheFirst == true)
                {
                    var badge = _context.Badges.AsQueryable().FirstOrDefault(b => b.Name_EN == "Winning streak");
                    if (badge != null)
                    {
                        Achievement achievement = new Achievement()
                        {
                            UserId = firstWinner.UserId,
                            ImageName = badge.ImageName,
                            Name_EN = badge.Name_EN,
                            Name_AR = badge.Name_AR
                        };
                        _context.Achievements.Add(achievement);

                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}

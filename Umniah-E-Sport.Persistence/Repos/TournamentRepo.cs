using Microsoft.EntityFrameworkCore;
using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class TournamentRepo : BaseManager<Tournament>,ITournamentManager
    {
        public TournamentRepo(UmniahContext context) : base(context)
        {
        }

        public IEnumerable<Tournament> GetFeaturedTournaments()
        {
            return _context.Tournaments.AsQueryable().Include(t => t.Location).Include(t => t.TournamentType).Where(t => t.IsFeatured && t.EndDate > DateTime.Now);
        }


        public IEnumerable<Tournament> GetFinishedTournamentsByUser(string email)
        {
            return _context.UserTournaments
                            .Include(ut => ut.Tournament)
                            .ThenInclude(t => t.Location)
                            .Include(ut => ut.Tournament)
                            .ThenInclude(t => t.TournamentType)
                            .Include(ut => ut.User)
                            .Where(ut => ut.User.Email == email)
                            .AsEnumerable()
                            .Where(ut => ut.Tournament.StartDate.Add(ut.Tournament.DurationTimeSpan) < DateTime.Now)
                            .Select(ut => ut.Tournament);
        }



        public List<Tournament> GetLiveTournamentsByArenaId(int arenaId)
        {
            return _context.Tournaments.AsQueryable().Where(t => t.ArenaId == arenaId && (t.StartDate < DateTime.Now && DateTime.Now < t.EndDate)).ToList();
        }

        public IEnumerable<Tournament> GetLiveTournamentsByUser(string email)
        {
            return _context.UserTournaments
                            .AsQueryable()
                            .Include(ut => ut.Tournament)
                            .ThenInclude(t => t.Location)
                            .Include(ut => ut.Tournament)
                            .ThenInclude(t => t.TournamentType)
                            .Include(ut => ut.User)
                            .Where(ut => ut.User.Email == email)
                            .Where(ut => ut.Tournament.StartDate < DateTime.Now
                            && DateTime.Now < ut.Tournament.EndDate)
                            .Select(ut => ut.Tournament);
        }




        // Not Used
        public int GetTournamentCapacity(int tournamentId)
        {
            return _context.Tournaments
                            .AsQueryable()
                            .FirstOrDefault(t => t.Id == tournamentId)?.Capacity ?? 0;
        }

        public IEnumerable<UserTournaments> GetTournamentLeaderboard(int tournamentId)
        {
            return _context.UserTournaments
                .AsQueryable()
                .Include(u => u.User)
                .Where(t => t.TournamentId == tournamentId).OrderByDescending(u => u.Score).Take(5);
        }

        public int GetTournamentRegistrantsCount(int tournamentId)
        {
            return _context.UserTournaments.AsQueryable().Where(ut => ut.TournamentId == tournamentId).Count();
        }

        public List<Tournament> GetTournamentsByGame(int gameId)
        {
            return _context.Tournaments
                            .AsQueryable()
                            .Include(t => t.Location)
                            .Include(t => t.TournamentType)
                            .Where(t => t.GameId == gameId).ToList();
        }

        public List<Tournament> GetUpcomingTournamentsByArenaId(int arenaId)
        {
            return _context.Tournaments
                            .AsQueryable()
                            .Where(t => t.ArenaId == arenaId && DateTime.Now < t.StartDate).ToList();
        }

        public IEnumerable<Tournament> GetUpcomingTournamentsByUser(string email)
        {
            return _context.UserTournaments
                .AsQueryable()
                .Include(ut => ut.Tournament)
                .ThenInclude(t => t.Location)
                .Include(ut => ut.Tournament)
                .ThenInclude(t => t.TournamentType)
                .Include(ut => ut.User)
                .Where(ut => ut.User.Email == email)
                .Where(ut => DateTime.Now < ut.Tournament.StartDate)
                .Select(ut => ut.Tournament);
        }

        public int NumberOfTournmentsByArena(int arenaId)
        {
            return _context.Tournaments
                            .AsQueryable()
                            .Where(t => t.ArenaId == arenaId).Count();
        }

        public List<Tournament> GetFinishedTournamentsByArenaId(int arenaId)
        {
            return _context.Tournaments.Where(t => t.ArenaId == arenaId && t.EndDate < DateTime.Now).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Contracts.Persistence
{
    public interface ITournamentManager : IAsyncManager<Tournament>
    {
        public IEnumerable<Tournament> GetFeaturedTournaments();
        public IEnumerable<Tournament> GetUpcomingTournamentsByUser(string Msisdn);
        public IEnumerable<Tournament> GetLiveTournamentsByUser(string Msisdn);
        public IEnumerable<Tournament> GetFinishedTournamentsByUser(string Msisdn);
        public List<Tournament> GetTournamentsByGame(int gameId);
        public int NumberOfTournmentsByArena(int arenaId);
        public int GetTournamentCapacity(int tournamentId);
        public int GetTournamentRegistrantsCount(int tournamentId);
        public IEnumerable<UserTournaments> GetTournamentLeaderboard(int tournamentId);
        public List<Tournament> GetLiveTournamentsByArenaId(int arenaId);
        public List<Tournament> GetFinishedTournamentsByArenaId(int arenaId);
        public List<Tournament> GetUpcomingTournamentsByArenaId(int arenaId);
    }
}

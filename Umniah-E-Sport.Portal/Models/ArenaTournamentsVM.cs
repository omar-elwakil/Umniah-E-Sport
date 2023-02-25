using System.Collections.Generic;

namespace Umniah_E_Sport.Portal.Models
{
    public class ArenaTournamentsVM
    {
        public ICollection<GetUpcomingTournamentsByArenaIdVM> UpcomingTournaments { get; set; }
        public ICollection<GetLiveTournamentsByArenaIdVM> LiveTournaments { get; set; }
        public ICollection<GetFinishedTournamentsByArenaIdVM> FinishedTournaments { get; set; }
    }
}

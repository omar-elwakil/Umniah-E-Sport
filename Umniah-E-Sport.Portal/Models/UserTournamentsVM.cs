using System.Collections.Generic;

namespace Umniah_E_Sport.Portal.Models
{
    public class UserTournamentsVM
    {
        public ICollection<GetUpcomingTournamentsVM> UpcomingTournaments { get; set; }
        public ICollection<GetLiveTournamentsVM> LiveTournaments { get; set; }
        public ICollection<GetFinishedTournamentsVM> FinishedTournaments { get; set; }
    }
}

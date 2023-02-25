using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetUpcomingTournaments
{
    public class GetUpcomingTournamentsVM
    {
        public string Organizer_EN { get; set; }
        public string Organizer_AR { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public long TimeStamp { get; set; }
        public string ImageName { get; set; }
        public int Id { get; set; }
        public string Description_EN { get; set; }
        public string Description_AR { get; set; }
        public int PrizeAmount { get; set; }
        public string TournamentTypeText_EN { get; set; }
        public string TournamentTypeText_AR { get; set; }
        public DateTime StartDate { get; set; }
        public string LocationText_EN { get; set; }
        public string LocationText_AR { get; set; }
        public double NumberOfMillisecond { get; set; }
    }
}

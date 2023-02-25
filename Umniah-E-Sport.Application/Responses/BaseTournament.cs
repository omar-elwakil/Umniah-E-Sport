using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umniah_E_Sport.Domain.Enums;

namespace Umniah_E_Sport.Application.Responses
{
    public class BaseTournament
    {
        public int Id { get; set; }
        public string Organizer_EN { get; set; }
        public string Organizer_AR { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string Description_EN { get; set; }
        public string Description_AR { get; set; }
        public int PrizeAmount { get; set; }
        public string TournamentTypeText_EN { get; set; }
        public string TournamentTypeText_AR { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterationStartDate { get; set; }
        public DateTime RegisterationEndDate { get; set; }
        public string DurationTimeSpan { get; set; }
        public int SubscriptionFee { get; set; }
        public double NumberOfMillisecond { get; set; }
        public string LocationText_EN { get; set; }
        public string LocationText_AR { get; set; }
        public string ImageName { get; set; }
        public string BannerName { get; set; }

        public int Capacity { get; set; }
        public int GameId { get; set; }
        public int LocationId { get; set; }
        public int TournamentTypeId { get; set; }
        public int? ArenaId { get; set; }
        public bool? IsFeatured { get; set; }
        public string DiscordLink { get; set; }
        public TournamentStatus? Status { get; set; }
        public RegisterationStatus? RegisterationStatus { get; set; }
    }
}

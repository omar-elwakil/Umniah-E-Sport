using Umniah_E_Sport.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Tournaments.Queries.GetTournamentsByUserId
{
    public class GetTournamentsByUserIdVm 
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int? ArenaId { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string Description_EN { get; set; }
        public string Description_AR { get; set; }
        public string ImageName { get; set; }
        public string BannerName { get; set; }
        public string Organizer_EN { get; set; }
        public string Organizer_AR { get; set; }
        public int Capacity { get; set; }
        public int TournamentTypeId { get; set; }
        public int LocationId { get; set; }
        public int PrizeAmount { get; set; }
        public bool IsFeatured { get; set; }
        public int SubscriptionFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public string DurationTimeSpan { get; set; }
        public bool IsDeleted { get; set; }
        //public string Code { get; set; }
        public string DiscordLink { get; set; }
    }
}

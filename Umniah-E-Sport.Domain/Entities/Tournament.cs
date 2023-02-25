using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual Arena Arena { get; set; }
        public int? ArenaId { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Title_EN { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Title_AR { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string Description_EN { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string Description_AR { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string ImageName { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string BannerName { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Organizer_EN { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Organizer_AR { get; set; }
        public int Capacity { get; set; }
        public virtual TournamentType TournamentType { get; set; }
        public int TournamentTypeId { get; set; }
        public virtual Location Location { get; set; }
        public int LocationId { get; set; }
        public int PrizeAmount { get; set; }
        public bool IsFeatured { get; set; }
        public int SubscriptionFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegisterationStartDate { get; set; }
        public DateTime RegisterationEndDate { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public TimeSpan DurationTimeSpan { get; set; }
        public bool IsDeleted { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string DiscordLink { get; set; }
        public virtual ICollection<UserTournaments> UserTournaments { get; set; }
    }
}

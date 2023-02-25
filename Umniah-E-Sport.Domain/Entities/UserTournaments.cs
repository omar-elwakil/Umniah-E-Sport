using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class UserTournaments
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string IngameId { get; set; }
        public int Score { get; set; }
        public virtual Tournament Tournament { get; set; }
        public int TournamentId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsTheFirst { get; set; }
        public bool IsJoinSmsSent { get; set; }
        public bool IsDailySmsSent { get; set; }
        public bool IsHourlySmsSent { get; set; }
    }
}

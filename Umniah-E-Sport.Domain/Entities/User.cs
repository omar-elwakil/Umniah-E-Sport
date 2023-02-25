using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string? Msisdn { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string? Email { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public DateTime? UnsubscribeTimeStamp { get; set; }
        public DateTime SubscribeTimeStamp { get; set; }
        public bool IsSubscribe { get; set; }
        //public UserStatus? userStatus { get; set; }
        public DateTime? RenewalDate { get; set; }
        public virtual ICollection<UserTournaments> UserTournaments { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<UserGames> UserGames { get; set; }
    }
}

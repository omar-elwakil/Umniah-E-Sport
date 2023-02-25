using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Title_EN { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Title_AR { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string ImageName { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string ShortCode { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string? GameLink { get; set; }
        public virtual TermsAndConditions TermsAndConditions { get; set; }
        public int TermsAndConditionsId { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
        public virtual ICollection<Video> videos { get; set; }
        public virtual ICollection<UserGames> UserGames { get; set; }
        public virtual ICollection<NewsEntity> News { get; set; }
        public bool IsDeleted { get; set; }
    }
}

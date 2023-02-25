using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class TermsAndConditions
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string Content_EN { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string Content_AR { get; set; }
        public DateTime? EndTimeStamp { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public bool IsDeleted { get; set; }
    }
}

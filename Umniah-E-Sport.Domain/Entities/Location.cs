using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Text_EN { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Text_AR { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class Arena
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Name_EN { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Name_AR { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string CountryName_EN { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string CountryName_AR { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}

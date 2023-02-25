using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class NewsEntity
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string ImageName { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Title_EN { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Title_AR { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string Description_EN { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string Description_AR { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime CreationTimeStamp { get; set; }
        public bool IsDeleted { get; set; }
    }
}

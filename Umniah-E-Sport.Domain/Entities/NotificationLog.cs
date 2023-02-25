using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class NotificationLog
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string MSISDN { get; set; }
        public int ActionType { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Response { get; set; }
        public DateTime CreationTimeStamp { get; set; }
    }
}

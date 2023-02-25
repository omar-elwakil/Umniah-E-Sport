using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class CasualGameImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int CasualGameId { get; set; }
        public virtual CasualGame CasualGame { get; set; }
        public bool IsDeleted { get; set; }
    }
}

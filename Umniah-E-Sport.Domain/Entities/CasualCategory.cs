using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Domain.Entities
{
    public class CasualCategory
    {
        public int Id { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<CasualGame> CasualGames { get; set; }
    }
}

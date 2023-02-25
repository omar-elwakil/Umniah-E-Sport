using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.Entities
{
    public class UserGames
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public int UserScore { get; set; }
    }
}

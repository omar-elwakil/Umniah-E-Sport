using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umniah_E_Sport.Domain.DTOs.LeaderBoard
{
    public class LeaderBoardRankDTO
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsCurrentUser { get; set; }
    }
}

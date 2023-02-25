using System.Collections.Generic;

namespace Umniah_E_Sport.Portal.Models
{
    public class MyLeaderboardViewModel
    {
        public List<LeaderBoardRankVM> Leaderboards { get; set; }
        public int ActiveLeaderboardIndex { get; set; }
        public string Game_Title_EN { get; set; }
        public string Game_Title_AR { get; set; }
    }
}

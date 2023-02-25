using System.Collections.Generic;

namespace Umniah_E_Sport.Application.Features.Users.Queries.MyLeaderBoard
{
    public class MyLeaderBoardVM
    {
        public string Title_EN { get; set; } //Game Title
        public string Title_AR { get; set; } //Game Title
        public List<LeaderBoardRankVM> LeaderBoardRankDTOs { get; set; }
    }
}

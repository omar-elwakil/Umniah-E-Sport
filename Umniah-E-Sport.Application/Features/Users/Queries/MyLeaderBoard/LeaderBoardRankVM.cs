namespace Umniah_E_Sport.Application.Features.Users.Queries.MyLeaderBoard
{
    public class LeaderBoardRankVM
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsCurrentUser { get; set; }
    }
}

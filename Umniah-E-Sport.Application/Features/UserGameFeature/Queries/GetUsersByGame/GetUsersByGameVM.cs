using Umniah_E_Sport.Domain.Entities;

namespace Umniah_E_Sport.Application.Features.UserGameFeature.Queries.GetUsersByGame
{
    public class GetUsersByGameVM
    {
        public int GameId { get; set; }
        public int UserScore { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Games.Queries.GetUserGamesByUserId
{
    public class GetUserGamesByUserIdVm
    {
        public int GameId { get; set; }
        public int UserScore { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string GameImageName { get; set; }
        public string GameShortCode { get; set; }
    }
}

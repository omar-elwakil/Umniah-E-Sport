using System;
using System.Collections.Generic;

namespace Umniah_E_Sport.Portal.Models
{
    public class HomeVm
    {
        public ICollection<ArenaCardVM> Arenas { get; set; }
        public ICollection<GetAllGamesVM> Games { get; set; }
        public ICollection<LatestNewsCardVM> News { get; set; }
        public ICollection<GetLatestVideosVm> Videos { get; set; }
        public ICollection<GetFeaturedTournamentsVM> Tournaments { get; set; }
        public ICollection<GetFeaturedCasualGamesVm> FeaturedCasualGames { get; set; }
        public ICollection<GetAllCasualCategoriesVm> CatualCategories { get; set; }
        public ICollection<LeaderBoardRankVM> leaderBoardRanks { get; set; }

      
    }
}

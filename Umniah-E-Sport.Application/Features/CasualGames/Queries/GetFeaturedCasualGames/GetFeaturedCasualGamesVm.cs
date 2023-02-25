using Umniah_E_Sport.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGames.Queries.GetFeaturedCasualGames
{
    public class GetFeaturedCasualGamesVm
    {
        public int Id { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string Description_EN { get; set; }
        public string Description_AR { get; set; }
        public string GameLink { get; set; }
        public string BannerImageName { get; set; }
        public string ThumbnailImageName { get; set; }
        public FileTypeEnum FileType { get; set; }
        public bool IsFreatured { get; set; }
        public string ProvidingBy { get; set; }
        public int CasualCategoryId { get; set; }
        public string CasualCategoryName_EN { get; set; }
        public string CasualCategoryName_AR { get; set; }
        public string CasualCategoryImageName { get; set; }
        public List<CasualGameImageVm> CasualGameImagesVm { get; set; }
    }
}

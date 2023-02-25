using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Umniah_E_Sport.Domain.Enums;

namespace Umniah_E_Sport.Domain.Entities
{
    public class CasualGame
    {
        public int Id { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string Description_EN { get; set; }
        public string Description_AR { get; set; }
        [Display(Name = "Game link/name")]
        public string GameLink { get; set; }
        [Display(Name = "Banner Image")]
        public string BannerImageName { get; set; }
        [Display(Name = "Thumbnail Image")]
        public string ThumbnailImageName { get; set; }
        [Display(Name = "Game type")]
        public FileTypeEnum FileType { get; set; }
        [Display(Name = "Is featured")]
        public bool IsFreatured { get; set; }

        [Display(Name = "Providing By")]
        public string ProvidingBy { get; set; }
        public int NumberOfClicked { get; set; }
        public int CasualCategoryId { get; set; }
        public virtual CasualCategory CasualCategory { get; set; }
        public virtual IList<CasualGameImage> CasualGameImages { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetLatestVideos
{
    public class GetLatestVideosVm
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string ImageName { get; set; }
        public string VideoFileName { get; set; }
        public string Title_AR { get; set; }
        public string Title_EN { get; set; }
        public string Description_AR { get; set; }
        public string Description_EN { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

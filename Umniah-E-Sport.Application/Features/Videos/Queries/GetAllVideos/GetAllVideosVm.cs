using System;

namespace Umniah_E_Sport.Application.Features.Videos.Queries.GetAllVideos
{
    public class GetAllVideosVm
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string ImageName { get; set; }
        public string VideoFileName { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string Description_EN { get; set; }
        public string Description_AR { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

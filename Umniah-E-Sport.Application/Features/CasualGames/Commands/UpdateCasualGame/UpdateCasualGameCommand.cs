using Umniah_E_Sport.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.CasualGames.Commands.UpdateCasualGame
{
    public class UpdateCasualGameCommand : IRequest<UpdateCasualGameResponse>
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
    }
}

using MediatR;
using System;

namespace Umniah_E_Sport.Application.Features.Games.Commands.AddGame
{
    public class AddGameCommand : IRequest<AddGameCommandResponse>
    {
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string ImageName { get; set; }
        public string ShortCode { get; set; }
        public string Content_EN { get; set; }
        public string Content_AR { get; set; }
        public DateTime? EndTimeStamp { get; set; }
        public DateTime CreationTimeStamp { get; set; }
    }
}

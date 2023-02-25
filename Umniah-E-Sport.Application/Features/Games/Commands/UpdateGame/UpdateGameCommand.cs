using MediatR;
using System;

namespace Umniah_E_Sport.Application.Features.Games.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest<UpdateGameCommandResponse>
    {
        public int Id { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string ImageName { get; set; }
        public string ShortCode { get; set; }
        public string TermsAndConditionsContent_EN { get; set; }
        public string TermsAndConditionsContent_AR { get; set; }
        public DateTime? TermsAndConditionsEndTimeStamp { get; set; }
    }
}

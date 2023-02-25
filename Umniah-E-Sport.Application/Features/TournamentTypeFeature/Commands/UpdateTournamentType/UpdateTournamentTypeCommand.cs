using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umniah_E_Sport.Application.Features.TournamentTypeFeature.Commands.UpdateTournamentType
{
    public class UpdateTournamentTypeCommand : IRequest<UpdateTournamentTypeCommandResponse>
    {
        public int Id { get; set; }
        public string Text_EN { get; set; }
        public string Text_AR { get; set; }
    }
}
